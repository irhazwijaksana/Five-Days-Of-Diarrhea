using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ngedenManager : MonoBehaviour
{
    public bool OnNgeden;
    public float FecesSpeed;
    public float MaxFeces;

    float Feces;

    public Slider FecesMeter;

    public bool FinishPoop;

    bool firstTime = true;

    public AudioSource ngedensfx;

    public GameObject Bar;
    public UnityEvent CebokSelesai;

    private void Start()
    {
        FecesMeter.maxValue = MaxFeces;
        FecesMeter.value = MaxFeces;
        Feces = MaxFeces;
    }

    public void UpdateFeces()
    {
        OnNgeden = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetBool("ngeden", true);
        ngedensfx.Play();
    }

    public void StopNgeden() 
    {
        OnNgeden = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetBool("ngeden", false);
        ngedensfx.Pause();
    }

    private void FixedUpdate()
    {
        if (OnNgeden) 
        {
            Feces -= FecesSpeed;
            FecesMeter.value = Feces;
        }

        if(Feces <= 0 && firstTime == true) 
        {
            FinishPoop = true;
            firstTime = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetBool("ngeden", false);
            CebokSelesai.Invoke();
            Bar.SetActive(false);
        }
    }
}
