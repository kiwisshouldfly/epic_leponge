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
    private bool hasShattered = false;

    //public float massthreshold = 1.0f;

    //audio variables
    public AudioSource shatterEffect;
    public AudioClip audioclip;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        shatterEffect.clip = audioclip;
        //Sprite sprite = cleansprite.mySprite;
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("colliding!");
        if (collision.gameObject.CompareTag("Sponge"))
        {
            Vector3 collidingObjectScale = collision.transform.localScale;
            spriteRenderer.sprite = cleansprite;

            if (canBeShattered == true && hasShattered == false)
            {
                if (collidingObjectScale.x > massThreshold.x &&
                collidingObjectScale.y > massThreshold.y &&
                collidingObjectScale.z > massThreshold.z)
                {
                    meetsThreshold = true;
                    shatterEffect.Play();
                    explodable.explode();
                    
                    hasShattered = true;
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


            if (collision.gameObject.GetComponent<FollowMouse>().exceeds == true && meetsThreshold == true && canBeShattered == true && hasShattered == false)
            {

                    Debug.Log("blah");
                    explodable.explode();
                    shatterEffect.Play();
                    hasShattered = true;

            }

           // Physics2D.IgnoreCollision();

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
        Physics2D.IgnoreLayerCollision(6,7);
        //Debug.Log("hi");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed!");
            explodable.explode();
        }

   
    }
}
