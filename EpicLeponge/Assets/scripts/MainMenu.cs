using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour 
{
 
    public GameObject startButton;
    

    void Start()
    {
      
    }
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    /*public void QuitApp()
    //{
        Application.Quit();
        Debug.Log("Application has been quit");

    }*/

    
}
