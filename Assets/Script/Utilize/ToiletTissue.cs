using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Global.Audio;

public class ToiletTissue : MonoBehaviour
{
    public ngedenManager _ngeden;

    bool OnTriggerMouse = false;

    private Renderer rendererd;

    public Color32 hoverColor;

    public UnityEvent Winning;

    void Start()
    {
        _ngeden = FindObjectOfType<ngedenManager>();
        rendererd = GetComponent<Renderer>(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && OnTriggerMouse)
        {
            FindObjectOfType<AudioManager>().SetCurrentSoundFXClip("tissue");
            OnTriggerMouse = false;
            Winning.Invoke();
        }
    }

    private void OnMouseEnter()
    {
        if (_ngeden.FinishPoop)
        {
            rendererd.material.color = hoverColor;
            OnTriggerMouse = true;
        }
    }

    private void OnMouseExit()
    {
        OnTriggerMouse = false;
        if (_ngeden.FinishPoop)
        {
            rendererd.material.color = Color.white;
        }
    }
}
