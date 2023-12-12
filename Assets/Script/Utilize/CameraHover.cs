using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global.Audio;

public class CameraHover : MonoBehaviour
{
    public GameObject DefaultCam;
    public GameObject RighCam;
    public GameObject LeftCam;

    public GameObject NgedenBar;

    public int PlayerPlace;

    void Start()
    {
        PlayerPlace = 0;
        DefaultCam.SetActive(true);
        RighCam.SetActive(false);
        LeftCam.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            if (PlayerPlace <= 0)
            {
                PlayerPlace += 1;
                SetPlace(PlayerPlace);
                //FindObjectOfType<AudioManager>().SetCurrentSoundFXClip("hover");
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (PlayerPlace >= 0)
            {
                PlayerPlace -= 1;
                SetPlace(PlayerPlace);
                //FindObjectOfType<AudioManager>().SetCurrentSoundFXClip("hover2");
            }
        }
    }

    public void SetPlace(int Setter)
    {
        DefaultCam.SetActive(false);
        RighCam.SetActive(false);
        LeftCam.SetActive(false);

        if (PlayerPlace == 0) 
        {
            DefaultCam.SetActive(true);
            NgedenBar.SetActive(true);
        }
        if (PlayerPlace == 1)
        {
            RighCam.SetActive(true);
            NgedenBar.SetActive(false);
        }
        if (PlayerPlace == -1)
        {
            LeftCam.SetActive(true);
            NgedenBar.SetActive(false);
        }
    }
}
