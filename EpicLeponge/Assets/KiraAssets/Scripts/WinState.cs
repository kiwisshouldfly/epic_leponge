using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    public GameObject[] allGameObjects;
    public bool wongame == false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject obj in allGameObjects)
        {
            if (obj.GetComponent<Shatterable>().hasCleaned == true)
            {
                Debug.Log("youwon!");
                SceneManager.LoadScene("EndScene");
            }
        }
        
    }
}
