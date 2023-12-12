using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhisperingManager : MonoBehaviour
{
    public bool WhisperOnRight;
    public GameObject WhisperRightObject;
    public bool WhisperOnLeft;
    public GameObject WhisperLeftObject;

    public float deadCount;
    public float MaxDeadCount;

    public float TimerInterval;
    public float MaxTimer, MinTimer;
    public bool WhisperActive;

    public CameraHover PlayerPos;

    private void Start()
    {
        StartInterval();
        PlayerPos = FindObjectOfType<CameraHover>();
    }

    public void StartInterval()
    {
        TimerInterval = Random.Range(MinTimer, MaxTimer);
        WhisperActive = false;
    }

    private void FixedUpdate()
    {
        if (TimerInterval >= 0)
        {
            TimerInterval -= Time.deltaTime;
        }
        else
        {
            if (!WhisperActive)
            {
                var RandomWhisper = Random.Range(-2, 2);
                SetWhisper(RandomWhisper);
            }
        }

        if (WhisperOnRight) 
        {
            if(PlayerPos.PlayerPlace == 1) 
            {
                WhisperRightObject.SetActive(true);
            }
            else 
            {
                WhisperRightObject.SetActive(false);
            }
            if(deadCount <= MaxDeadCount)
            {
                deadCount += Time.deltaTime;
            }
            else 
            {
                //dead
                GameObject.FindGameObjectWithTag("gameover").GetComponent<Animator>().SetTrigger("over");
                WhisperOnRight = false;
            }
        }
        if (WhisperOnLeft)
        {
            if (PlayerPos.PlayerPlace == -1)
            {
                WhisperLeftObject.SetActive(true);
            }
            else 
            {
                WhisperLeftObject.SetActive(false);
            }
            if (deadCount <= MaxDeadCount)
            {
                deadCount += Time.deltaTime;
            }
            else
            {
                //dead
                GameObject.FindGameObjectWithTag("gameover").GetComponent<Animator>().SetTrigger("over");
                WhisperOnLeft = false;
            }
        }
    }

    public void SetWhisper(int RandomWhisper) 
    {
        WhisperActive = true;
        if (RandomWhisper >= 0) 
        {
            WhisperOnRight = true;
        }
        else 
        {
            WhisperOnLeft = true;
        }
    }

    public void Knocked(int TargetWall) 
    {
        // right
        if(TargetWall == 1) 
        {
            if (WhisperOnRight) 
            {
                WhisperOnRight = false;
                deadCount = 0;
                StartInterval();
                WhisperRightObject.SetActive(false);
            }
        }

        // left
        if (TargetWall == -1)
        {
            if (WhisperOnLeft)
            {
                WhisperOnLeft = false;
                deadCount = 0;
                StartInterval();
                WhisperLeftObject.SetActive(false);
            }
        }
    }
}
