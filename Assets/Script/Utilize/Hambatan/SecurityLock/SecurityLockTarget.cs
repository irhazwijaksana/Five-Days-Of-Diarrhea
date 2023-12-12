using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global.Audio;

public class SecurityLockTarget : MonoBehaviour
{
    private Renderer rendererd;
    bool OnTriggerMouse = false;

    public bool Onlock;

    public CameraHover playerplace;

    public Animator Locks;

    public Color32 hoverColor;

    void Start()
    {
        rendererd = GetComponent<Renderer>();
        playerplace = FindObjectOfType<CameraHover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && OnTriggerMouse && !Onlock && playerplace.PlayerPlace == 0)
        {
            FindObjectOfType<AudioManager>().SetCurrentSoundFXClip("kunci");
            FindObjectOfType<SecurityLock>().ResetLock();
            FindObjectOfType<HambatanManager>().AddNoice();
            OnTriggerMouse = false;
        }

        if (!Onlock) 
        {
            Locks.SetBool("locked", false);
        }
        if (Onlock)
        {
            Locks.SetBool("locked", true);
            rendererd.material.color = Color.white;
        }

        if (playerplace.PlayerPlace != 0)
        {
            OnTriggerMouse = false;
            rendererd.material.color = Color.white;
        }
    }

    private void OnMouseEnter()
    {
        if (!Onlock && playerplace.PlayerPlace == 0)
        {
            rendererd.material.color = hoverColor;
            OnTriggerMouse = true;
        }
    }

    private void OnMouseExit()
    {
        if (!Onlock && playerplace.PlayerPlace == 0)
        {
            OnTriggerMouse = false;
            rendererd.material.color = Color.white;
        }
    }
}
