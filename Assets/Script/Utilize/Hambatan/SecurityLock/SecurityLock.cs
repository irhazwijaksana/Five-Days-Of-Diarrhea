using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global.Audio;

public class SecurityLock : MonoBehaviour
{
    public float MaxLockTime;
    public float timer;
    public float MaxDeadCount;
    private float DeadCount;
    public SecurityLockTarget target;

    private void Start()
    {
        target = FindObjectOfType<SecurityLockTarget>();   
    }

    public void FixedUpdate()
    {
        if (target.Onlock)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                target.Onlock = false;
                FindObjectOfType<AudioManager>().SetCurrentSoundFXClip("kunci");
            }
        }

        if(target.Onlock == false) 
        {
            if (DeadCount <= MaxDeadCount)
            {
                DeadCount += Time.deltaTime;
            }
            else 
            {
                GameObject.FindGameObjectWithTag("gameover").GetComponent<Animator>().SetTrigger("over");
            }
        }
    }

    public void ResetLock() 
    {
        target.Onlock = true;
        timer = MaxLockTime;
        DeadCount = 0;
    }
}
