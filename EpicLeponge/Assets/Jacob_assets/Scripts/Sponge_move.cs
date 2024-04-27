using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge_move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10.0f;
    //private Camera_manager = cam_manager.GetComponent<>
    private GameObject camera_manager;
    public Camera_manager manager;
    public Rigidbody2D rbSponge;
    public Rigidbody2D rbRotation;
    public float slowdownRate = 0.5f;
    public float moveSpeed = 5f;


    public PlayerShoot findIfSpongeActive;
    void Awake()
    {
        Vector3 newPosition = new Vector3(rbSponge.position.x, rbSponge.position.y, 0);
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(0f, 0f, rbSponge.rotation);

        Vector2 direction = transform.up;

        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(direction * speed, ForceMode2D.Impulse);
        manager.SwitchToNewCamera();
}

    // Update is called once per frame
    void Update()
    {
        rb.velocity *= Mathf.Clamp01(1f - slowdownRate * Time.deltaTime);
        Debug.Log(transform.rotation);

        //if (Input.GetMouseButtonDown(0))
        //{
         //   Debug.Log("pls");
         //   Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          //  clickPosition.z = 0f;

          //  Vector2 moveDirection = (clickPosition - transform.position).normalized;

          //  rb.AddForce(moveDirection * moveSpeed, ForceMode2D.Impulse);
        //}

    }
}
