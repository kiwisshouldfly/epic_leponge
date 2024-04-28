using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    public GameObject[] allGameObjects;
    //public bool wongame = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pls");
            DONEplease();
        }
        //private bool isWon()
        {
            int clean = 0;
            for (int i = 0; i < allGameObjects.Length; i++)
            {
                if (allGameObjects[i].GetComponent<Shatterable>().hasCleaned)
                {
                    clean++;
                    Debug.Log(clean + " have been cleaned out of " + allGameObjects.Length);
                }
                if (clean == allGameObjects.Length - 1)
                {
                    Debug.Log("You won!");
                    DONEplease();
                }
            }
            
            
        }
       
        void DONEplease()
        {
            Application.Quit();
        }
        //bool allCleaned = true;
        //foreach(GameObject obj in allGameObjects)
        //{
        //    if (obj.GetComponent<Shatterable>().hasCleaned == true)
         //   {
         //       Debug.Log("youwon!");
                //SceneManager.LoadScene("EndScene");
        //    }
        
        
    }
}
