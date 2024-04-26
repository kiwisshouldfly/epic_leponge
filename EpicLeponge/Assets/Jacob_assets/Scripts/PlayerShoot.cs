using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject sponge;
    public Transform sponge_spawn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire!");
            Instantiate(sponge, sponge_spawn.position, sponge_spawn.rotation);
        }    
    }

   
}
