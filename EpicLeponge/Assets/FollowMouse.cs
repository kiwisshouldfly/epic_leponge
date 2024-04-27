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
   
    void Start()
    {
        previousPosition = transform.position;
        //previousTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Vector3.Distance(transform.position, previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
        //previousPosition = transform.position;
       // Vector3 currentPosition = transform.position;
       // float currentTime = Time.time;

       // Vector3 displacement = currentPosition - previousPosition;
        
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        worldMousePosition.z = 0f;

        //Vector3 displacement = worldMousePosition - previousPosition;

       // float timeInterval = Time.time - previousTime;

       // Vector3 velocity = displacement / timeInterval;

        //previousPosition = worldMousePosition;
        //previousTime = Time.time;

        transform.position = worldMousePosition;

        if (speed > 0)
        {
            if (speed > 200)
            {
                exceeds = true;
            }
            else
            {
                exceeds = false;
            }
            Debug.Log(speed);
        }
    }
}

// if velocity.magnitude > 400; shatter 