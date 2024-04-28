  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiraShoot : MonoBehaviour
{
    public GameObject sponge;
    public bool sponge_shoot = false;
    private float shoot_multiplier = 1f;
    private float mouseButtonDownTime = 0f;
    private bool isMouseButtonPressed = false;
    public float maxMultiplier = 4f;
    public float minMultiplier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log(isMouseButtonPressed);
        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating("AddMultiplier", 0, 1);

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("released");
            isMouseButtonPressed = false;
            CancelInvoke();
            sponge_shoot = true;
            sponge.GetComponent<FollowMouse>().multiplier = shoot_multiplier;
            sponge.GetComponent<FollowMouse>().shotout();
            shoot_multiplier = 1f;
        }
        
       // if (Input.GetButtonDown("Fire1") && sponge_shoot == false)
      //  {
     //       Debug.Log("fire!");

     //       sponge_shoot = true;
     //       sponge.GetComponent<FollowMouse>().shotout();
     //   }
        
    }

    void AddMultiplier()
    {
        shoot_multiplier += 0.5f;
        shoot_multiplier = Mathf.Clamp(shoot_multiplier, minMultiplier, maxMultiplier);
        Debug.Log(shoot_multiplier);
    }
}
