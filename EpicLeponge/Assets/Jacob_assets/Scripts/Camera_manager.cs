using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_manager : MonoBehaviour
{
    public GameObject player_camera;
    public GameObject sponge_camera;
    public bool isPlayerCam = true;

    // Start is called before the first frame update
    void Start()
    {
        CamSetPlayer();
    }

    public void SwitchToNewCamera()
    {
        if(isPlayerCam)
        {
            CamSetSponge();
            isPlayerCam = false;
        }
        else
        {
            CamSetPlayer();
            isPlayerCam = true;
        }

    }

    void CamSetPlayer()
    {
        player_camera.SetActive(true);
        sponge_camera.SetActive(false);
    }

    void CamSetSponge()
    {
        player_camera.SetActive(false);
        sponge_camera.SetActive(true);
    }
}
