using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject sponge;
    public Transform sponge_spawn;
    private bool sponge_shoot = false;




    // Start is called before the first frame update
    void Start()
    {
        sponge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && sponge_shoot == false)
        {
            Debug.Log("Fire!");
            //Instantiate(sponge, sponge_spawn.position, sponge_spawn.rotation);
            sponge.SetActive(true);
            sponge_shoot = true;
            
        }
        
    }

   
}
