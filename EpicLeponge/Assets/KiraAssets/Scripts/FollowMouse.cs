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

    // variables for rotating upon shooting
    public Rigidbody2D playerspawnrot;
    public float slowdownRate = 0.5f;

    //variables for left + right movement when shooting
    public float leftForce = -0.1f;
    public float rightForce = 0.1f;
    public float burstDuration = 0.2f;
   

    void Start()
    {
        targetScale = transform.localScale;
        spriteRenderer.enabled = false;
    }

    public void Getdirty()
    {
        targetScale += new Vector3(scaleIncreaseAmount * 10, scaleIncreaseAmount * 10, scaleIncreaseAmount * 10);

        targetScale = Vector3.Min(targetScale, new Vector3(maxScale, maxScale, maxScale));
    }

    public void shotout()
    {
        Vector3 newPosition = new Vector3(playerspawnrot.position.x, playerspawnrot.position.y, 0);
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(0f, 0f, playerspawnrot.rotation);
        Vector2 direction = transform.up;

        isShot = true;
        spriteRenderer.enabled = true;
        rb.AddRelativeForce(direction * speed, ForceMode2D.Impulse);
        manager.SwitchToNewCamera();
    }

 
    // Update is called once per frame
    void Update()
    {
        if (isShot == true)
        {
            rb.velocity *= Mathf.Clamp01(1f - slowdownRate * Time.deltaTime);
            Debug.Log(transform.rotation);
            float horizontalInput = Input.GetAxis("Horizontal");

            if (horizontalInput < 0)
            {
                Debug.Log("inputleft");
                rb.AddRelativeForce(Vector2.right * leftForce, ForceMode2D.Impulse);
            }
            else if (horizontalInput > 0)
            {
                rb.AddRelativeForce(Vector2.left * leftForce, ForceMode2D.Impulse);
            }
            //if (Input.GetMouseButtonDown(0))
            //{
                //Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //clickPosition.z = 0f;

                //Vector2 moveDirection = (clickPosition - transform.position).normalized;

                //rb.AddForce(moveDirection * moveSpeed, ForceMode2D.Impulse);
            //}
            //Debug.Log(targetScale);
            if (touchingdirty == true)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, targetScale, lerpSpeed);
            }
        }

      //  IEnumerator ApplyForce(Vector2 force)
      //  {
            //Apply the force
    //        rb.AddForce(force, ForceMode2D.Force);
     //       yield return new WaitForSeconds(burstDuration);
      //      rb.velocity = new Vector2(moveSpeed, rb.velocity.x);
     //   }

       
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