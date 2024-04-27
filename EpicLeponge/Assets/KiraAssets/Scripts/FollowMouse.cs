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

    public float scaleIncreaseAmount = 3f;
    public float lerpSpeed = 0.1f;
    public float maxScale = 10.0f;

    private Vector3 targetScale;
    public bool touchingdirty = false;

    

    void Start()
    {
        targetScale = transform.localScale;
        
    }

    public void Getdirty()
    {
        targetScale += new Vector3(scaleIncreaseAmount * 10, scaleIncreaseAmount * 10, scaleIncreaseAmount * 10);

        targetScale = Vector3.Min(targetScale, new Vector3(maxScale, maxScale, maxScale));
    }

 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0f;

            Vector2 moveDirection = (clickPosition - transform.position).normalized;

            rb.AddForce(moveDirection * moveSpeed, ForceMode2D.Impulse);
        }
        //Debug.Log(targetScale);
        if (touchingdirty ==  true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, lerpSpeed);
        }

       
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