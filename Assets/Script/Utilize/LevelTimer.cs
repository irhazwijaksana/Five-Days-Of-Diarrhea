using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public float MaxTime;
    public float Timer;
    public bool TimerOn;
    public Text TImeUI;

    public void StartTheCount() 
    {
        Timer = MaxTime;
        TimerOn = true;
    }

    public void StopCounting()
    {
        TimerOn = false;
    }

    void Update()
    {
        TImeUI.text = ((int)Timer) + "s";
        if (TimerOn) 
        {
            Timer -= Time.deltaTime;
            if(Timer <= 0) 
            {
                GameObject.FindGameObjectWithTag("gameover").GetComponent<Animator>().SetTrigger("over");
                TimerOn = false;
            }
        }
    }
}
