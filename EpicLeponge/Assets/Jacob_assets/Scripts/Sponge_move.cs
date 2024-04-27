using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge_move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.up * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
