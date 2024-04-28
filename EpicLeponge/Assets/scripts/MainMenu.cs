using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour 
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    private bool VideoFinished = false;
    public GameObject startButton;
    public GameObject quitButton;
    public GameObject options;

    void Start()
    {
        Debug.Log("started");
        videoPlayer.loopPointReached += OnVideoFinished;
        startButton.SetActive(false);
        quitButton.SetActive(false);
        options.SetActive(false);
    }
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has been quit");

    }

    void OnVideoFinished(VideoPlayer source)
    {
        Debug.Log("finished");
        audioSource.Play();
        VideoFinished = true;
        startButton.SetActive(true);
        quitButton.SetActive(true);
        options.SetActive(true);
    }
}
