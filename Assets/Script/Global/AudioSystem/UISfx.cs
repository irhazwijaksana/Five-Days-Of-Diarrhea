using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global.Audio;

public class UISfx : MonoBehaviour
{
    public string sfxName;

    public void PlaySFX(string sfxName)
    {
        FindObjectOfType<AudioManager>().SetCurrentSoundFXClip(sfxName);
    }
}
