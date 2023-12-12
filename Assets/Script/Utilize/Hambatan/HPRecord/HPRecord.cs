using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global.Audio;

public class HPRecord : MonoBehaviour
{
    public Transform HPTarget;
    public float XMaxpos, XminPos;
    public float Countdown;
    public float timer;

    public int KnockedValue;

    void Start()
    {
        FindObjectOfType<DoorKnocked>().AddHprecordAuto(this);
        var RandomPlace = Random.Range(XminPos, XMaxpos);
        HPTarget.transform.localPosition = new Vector3(RandomPlace, 0, 0);
        timer = Countdown;
    }

    private void FixedUpdate()
    {
        if(timer >= 0) 
        {
            timer -= Time.deltaTime;
        }
        else 
        {
            GameObject.FindGameObjectWithTag("gameover").GetComponent<Animator>().SetTrigger("over");
        }


        if(KnockedValue >= 3) 
        {
            FindObjectOfType<AudioManager>().SetCurrentSoundFXClip("hpdrop");
            ResetHambatan();
        }
    }

    public void Knocked() 
    {
        KnockedValue += 1;
    }

    public void ResetHambatan()
    {
        FindObjectOfType<DoorKnocked>().RemoveHprecordAuto(this);
        FindObjectOfType<HambatanManager>().StartInterval();
        Destroy(this.gameObject);
    }
}
