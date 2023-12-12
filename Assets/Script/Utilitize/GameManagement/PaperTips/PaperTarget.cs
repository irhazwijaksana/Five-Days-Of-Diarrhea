using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Global.Audio;

public class PaperTarget : MonoBehaviour
{
    bool OnTriggerMouse = false;
    private Renderer rendererd;
    public Color32 hoverColor;

    public UnityEvent OpenPaper;

    void Start()
    {
        rendererd = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && OnTriggerMouse)
        {
            FindObjectOfType<AudioManager>().SetCurrentSoundFXClip("tissue");
            FindObjectOfType<gamemaster>().pause();
            OpenPaper.Invoke();
            OnTriggerMouse = false;
        }
    }

    private void OnMouseEnter()
    {
         rendererd.material.color = hoverColor;
         OnTriggerMouse = true;
    }

    private void OnMouseExit()
    {
        OnTriggerMouse = false;
        rendererd.material.color = Color.white;
    }
}
