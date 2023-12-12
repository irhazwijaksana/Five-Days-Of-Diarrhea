using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverEffector : MonoBehaviour
{

    public UnityEvent GameOverEvent;

    public void StartEndingEvent() 
    {
        GameOverEvent.Invoke();
    }

    public UnityEvent JumpscareEvent;

    public void StartJupscare()
    {
        JumpscareEvent.Invoke();
    }
}
