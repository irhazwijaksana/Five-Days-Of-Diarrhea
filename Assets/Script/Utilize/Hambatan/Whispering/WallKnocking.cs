using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global.Audio;

public class WallKnocking : MonoBehaviour
{
    public int WallNumber;

    public CameraHover PlayerPos;

    public GameObject Notif;


    public void Knocking() 
    {
        FindObjectOfType<AudioManager>().SetCurrentSoundFXClip("knocking");
        FindObjectOfType<WhisperingManager>().Knocked(WallNumber);
        FindObjectOfType<HambatanManager>().AddNoice();
    }


    private Renderer rendererd;
    bool OnTriggerMouse = false;
    void Start()
    {
        rendererd = GetComponent<Renderer>();
        PlayerPos = FindObjectOfType<CameraHover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && OnTriggerMouse && PlayerPos.PlayerPlace == WallNumber)
        {
            Knocking();
            OnTriggerMouse = false;     
        }
        if (PlayerPos.PlayerPlace != WallNumber) 
        {
            OnTriggerMouse = false;
            Notif.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        if (PlayerPos.PlayerPlace == WallNumber)
        {
            Notif.SetActive(true);
            OnTriggerMouse = true;
        }
    }

    private void OnMouseExit()
    {
        if (PlayerPos.PlayerPlace == WallNumber)
        {
            OnTriggerMouse = false;
            Notif.SetActive(false);
        }
    }
}
