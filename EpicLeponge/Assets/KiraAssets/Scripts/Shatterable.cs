using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatterable : MonoBehaviour
   
{
    public Transform test;
    public Explodable explodable;
    SpriteRenderer spriteRenderer;

    public Sprite cleansprite;
    public Vector3 massThreshold = new Vector3 (1, 1, 1);
    private bool hasCollided = false;
    private bool meetsThreshold = false;
    public bool canBeShattered = false;
    //public float massthreshold = 1.0f;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        //Sprite sprite = cleansprite.mySprite;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sponge"))
        {
            Vector3 collidingObjectScale = collision.transform.localScale;
            spriteRenderer.sprite = cleansprite;

            if (canBeShattered == true)
            {
                if (collidingObjectScale.x > massThreshold.x &&
                collidingObjectScale.y > massThreshold.y &&
                collidingObjectScale.z > massThreshold.z)
                {
                    meetsThreshold = true;
                    Debug.Log("threshold");
                    explodable.explode();
                }
            }

            if (!hasCollided)
            {
                    collision.gameObject.GetComponent<FollowMouse>().Getdirty();
                    collision.gameObject.GetComponent<FollowMouse>().touchingdirty = true;

                    hasCollided = true;
                    Debug.Log(hasCollided);
                    //spriteRenderer.color = Color.white;
            }


            if (collision.gameObject.GetComponent<FollowMouse>().exceeds == true && meetsThreshold == true && canBeShattered == true)
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
