using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatterable : MonoBehaviour
   
{
    public Transform test;
    public Explodable explodable;
    SpriteRenderer spriteRenderer;
    private bool hasCollided = false;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
   
        if (collision.gameObject.CompareTag("Sponge"))
        {

            if (!hasCollided)
            {
                collision.gameObject.GetComponent<FollowMouse>().Getdirty();
                collision.gameObject.GetComponent<FollowMouse>().touchingdirty = true;

                hasCollided = true;
                spriteRenderer.color = Color.white;
            }
  
           if (collision.gameObject.GetComponent<FollowMouse>().exceeds == true)

            {
                Debug.Log("blah");
                explodable.explode();
                
            }
            
        }
    }

    //void OnCollisionExit2D(Collision2D collision)
   // {
   //     if (collision.gameObject.CompareTag("Sponge"))
   //     {
   //         collision.gameObject.GetComponent<FollowMouse>().touchingdirty = false;
   //     }
  //  }
     


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
