using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global.Audio;

public class DoorKnocked : MonoBehaviour
{
    private Renderer rendererd;
    bool OnTriggerMouse = false;

    public CameraHover playerplace;

    public Color32 hoverColor;

    List<HPRecord> hambatanRecord = new List<HPRecord>();

    void Start()
    {
        rendererd = GetComponent<Renderer>();
        playerplace = FindObjectOfType<CameraHover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && OnTriggerMouse && playerplace.PlayerPlace == 0)
        {
            FindObjectOfType<HambatanManager>().AddNoice();
            FindObjectOfType<AudioManager>().SetCurrentSoundFXClip("knocking");
            OnTriggerMouse = false;
            if(hambatanRecord != null) 
            {
                foreach(HPRecord hp in hambatanRecord) 
                {
                    hp.Knocked();
                }
            }
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

    public void AddHprecordAuto(HPRecord recordHp) 
    {
        hambatanRecord.Add(recordHp);
    }
    public void RemoveHprecordAuto(HPRecord recordHp)
    {
        hambatanRecord.Remove(recordHp);
    }
}
