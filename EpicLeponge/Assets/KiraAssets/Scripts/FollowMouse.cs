using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 previousPosition;
    private float previousTime;
    public Vector3 velocity;
    public bool exceeds = false;
    public Rigidbody2D rb;
    public float speed;
    public float moveSpeed = 5f;
    public Camera_manager manager;

    public float scaleIncreaseAmount = 3f;
    public float lerpSpeed = 0.1f;
    public float maxScale = 10.0f;

    private Vector3 targetScale;
    public bool touchingdirty = false;
    public SpriteRenderer spriteRenderer;
    public bool isShot = false;
    private Vector3 startPos;
    public float multiplier;

    public AudioSource audioSource;
    public AudioClip audioClip;
    
    // variables for rotating upon shooting
    public Rigidbody2D playerspawnrot;
    public float slowdownRate = 0.5f;

    //resetting shooting
    public KiraShoot player;
    public float cooldown = 0.5f;

    //adding force when shooting
    public float shootforce = 1f;

    void Start()
    {
        targetScale = transform.localScale;
        spriteRenderer.enabled = false;
        //setting start position
        startPos = transform.localPosition;
        //targetRot = transform.localRotation;

    }

    void resetPos()
    {
        spriteRenderer.enabled = false;
       // transform.rotation = Quaternion.Euler(0f, 0f, playerspawnrot.rotation);
        //Vector3 newPosition = new Vector3(playerspawnrot.position.x, playerspawnrot.position.y, 0);
       // transform.position = transform;
        transform.rotation = Quaternion.Euler(0f, 0f, 1f);
        transform.position = startPos;


    }

    public void Getdirty()
    {
        targetScale += new Vector3(scaleIncreaseAmount * 10, scaleIncreaseAmount * 10, scaleIncreaseAmount * 10);

        //targetScale = Vector3.Min(targetScale, new Vector3(maxScale, maxScale, maxScale));
    }


    public void shotout()
    {
        Vector3 newPosition = new Vector3(playerspawnrot.position.x, playerspawnrot.position.y, 0);
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(0f, 0f, playerspawnrot.rotation);
        Vector2 direction = transform.up;
        Debug.Log(transform.rotation);

        isShot = true;
        spriteRenderer.enabled = true;
        rb.AddRelativeForce(direction * speed * multiplier, ForceMode2D.Impulse);
        manager.SwitchToNewCamera();
    }

 
    // Update is called once per frame
    void Update()
    {
        if (isShot == true)
        {
            rb.velocity *= Mathf.Clamp01(1f - slowdownRate * Time.deltaTime);
          
            Debug.Log(rb.velocity);
            
            if ((rb.velocity.x < cooldown && rb.velocity.x > -cooldown) && (rb.velocity.y < cooldown && rb.velocity.y > -cooldown))
            {
                //Debug.Log("yippe!");
                isShot = false;
                manager.SwitchToNewCamera();
                player.sponge_shoot = false;
                resetPos();
            }


            if (touchingdirty == true)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, targetScale, lerpSpeed);
            }
        }
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("splat!");
        audioSource.Play();
    }
    void FixedUpdate()
    {
        float speed = rb.velocity.magnitude;
        //Debug.Log(speed);
        //Debug.Log(exceeds);
        if (speed > 7)
        {
            exceeds = true;
        }
        else
        {
            exceeds = false;
        }
    }
}

// if velocity.magnitude > 400; shatter 