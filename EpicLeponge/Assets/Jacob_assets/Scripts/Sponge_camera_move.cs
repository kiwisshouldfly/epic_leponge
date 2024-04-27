using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge_camera_move : MonoBehaviour
{
    public Rigidbody2D sponge_position;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        HandleCameraMovement();
        

    }


    public void HandleCameraMovement()
    {
        Vector3 newPosition = new Vector3(sponge_position.position.x, sponge_position.position.y, 0) + offset;
        transform.position = newPosition;
        Debug.Log(sponge_position.position);
    }
}
