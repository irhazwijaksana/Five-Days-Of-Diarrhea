using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrepeTarget : MonoBehaviour
{
    public Renderer rendererd;
    bool OnTriggerMouse = false;
    public Color32 hoverColor;
    public CameraHover playerplace;
    void Start() 
    { 
        rendererd = GetComponent<Renderer>();
        playerplace = FindObjectOfType<CameraHover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && OnTriggerMouse && playerplace.PlayerPlace == 0)
        {
            FindObjectOfType<HandGrepe>().ResetHambatan();
            OnTriggerMouse = false;
        }

        if (playerplace.PlayerPlace != 0) 
        {
            OnTriggerMouse = false;
            rendererd.material.color = Color.white;
        }
    }

    private void OnMouseOver()
    {
        if (playerplace.PlayerPlace == 0)
        {
            rendererd.material.color = hoverColor;
            OnTriggerMouse = true;
        }
    }

    private void OnMouseExit()
    {
        if (playerplace.PlayerPlace == 0)
        {
            OnTriggerMouse = false;
            rendererd.material.color = Color.white;
        }
    }
}
