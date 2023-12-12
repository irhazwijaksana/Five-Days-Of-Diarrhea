using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityPatrol : MonoBehaviour
{
    public float MaxTime, MinTime;

    public float timer;
    float ActiveTime;

    private void Start()
    {
        var RandomNumber = Random.Range(MinTime, MaxTime);
        timer = RandomNumber;
        ActiveTime = RandomNumber - 3;
    }

    private void FixedUpdate()
    {
        if(timer >= 0) 
        {
            timer -= Time.deltaTime;

            if (ActiveTime >= timer)
            {
                if (FindObjectOfType<HambatanManager>().Noice || FindObjectOfType<ngedenManager>().OnNgeden)
                {
                    GameObject.FindGameObjectWithTag("gameover").GetComponent<Animator>().SetTrigger("over");
                }
            }
        }
        else 
        {
            ResetHambatan();
        }
    }

    public void ResetHambatan()
    {
        FindObjectOfType<HambatanManager>().StartInterval();
        Destroy(this.gameObject);
    }
}
