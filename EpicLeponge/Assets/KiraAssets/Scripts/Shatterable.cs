using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatterable : MonoBehaviour
   
{
    public Transform test;
    public Explodable explodable;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sponge"))
        {
  
           if (collision.gameObject.GetComponent<FollowMouse>().exceeds == true)
            {
                Debug.Log("blah");
                explodable.explode();
            }
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("hi");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed!");
            explodable.explode();
        }

   
    }
}
