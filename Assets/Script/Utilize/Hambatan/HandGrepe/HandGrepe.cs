using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrepe : MonoBehaviour
{
    public Transform HandTarget;
    public float XMaxpos, XminPos;
    public float Countdown;
    public float timer; 

    void Start()
    {
        var RandomPlace = Random.Range(XminPos, XMaxpos);
        HandTarget.transform.localPosition = new Vector3(0, 0, RandomPlace);
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
    }

    public void ResetHambatan()
    {
        FindObjectOfType<HambatanManager>().StartInterval();
        FindObjectOfType<HambatanManager>().ShootThehose();
        Destroy(this.gameObject);
    }
}
