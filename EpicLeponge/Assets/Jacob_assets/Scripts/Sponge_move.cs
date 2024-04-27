using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge_move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10.0f;
    public GameObject cam_manager;
    //private Camera_manager = cam_manager.GetComponent<>
    private GameObject camera_manager;
    public Camera_manager manager;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.up * speed, ForceMode2D.Impulse);

        //camera_manager = GameObject.Find("Camera_Manager");
        manager.SwitchToNewCamera();


}

    // Update is called once per frame
    void Update()
    {
        
    }
}
