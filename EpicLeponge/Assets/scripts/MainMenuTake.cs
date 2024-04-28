using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MainMenuTake : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    private bool VideoFinished = false;
    public GameObject startButton;
    public GameObject quitButton;
    public GameObject controlButton;

    void Start()
    {
        Debug.Log("started");
        videoPlayer.loopPointReached += OnVideoFinished;
        startButton.SetActive(false);
        quitButton.SetActive(false);
        controlButton.SetActive(false);

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
        controlButton.SetActive(true);
    }
}