  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiraShoot : MonoBehaviour
{
    public GameObject sponge;
    public bool sponge_shoot = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && sponge_shoot == false)
        {
            Debug.Log("fire!");

            sponge_shoot = true;
            sponge.GetComponent<FollowMouse>().shotout();
        }
        
    }
}
