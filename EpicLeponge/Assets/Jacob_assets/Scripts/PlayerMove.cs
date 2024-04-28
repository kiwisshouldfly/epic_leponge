using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public SpriteRenderer spriteRenderer;
    public Sprite[] newDirection;
    public GameObject spriteContainer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;

        if ((mousePosition.x > 1.71) && (mousePosition.y < -2.29))
        {
            spriteRenderer.sprite = newDirection[3];
        }
        if ((mousePosition.x < -3.04) && (mousePosition.y < -0.93))
        {
            spriteRenderer.sprite = newDirection[2];
        }
        if ((mousePosition.x < 3.04) && (mousePosition.y > -0.93))
        {
            spriteRenderer.sprite = newDirection[0];
        }
        
        Debug.Log(mousePosition);
    }
}
