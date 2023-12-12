using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Global.Audio;

public class HambatanManager : MonoBehaviour
{
    public GameObject[] Hambatannya;
    public int JumlahHambatan;
    public float TimerInterval;

    public Transform PrefabSpawn;

    public int MaxInterval, MinInterval;

    bool HambatanActive;

    public UnityEvent ShootTheHoe;
    public UnityEvent AfterShoot;


    // Noice Hambatan................
    public bool Noice;
    private float NoiceTimer;

    private void Start()
    {
        var RandomHambatan = Random.Range(0, JumlahHambatan);
        StartInterval();
    }

    public void SetHambatan(int hambatanSet) 
    {
        Instantiate(Hambatannya[hambatanSet], PrefabSpawn.transform.position, Quaternion.identity);
        HambatanActive = true;
    }

    public void StartInterval() 
    {
        TimerInterval = Random.Range(MinInterval, MaxInterval);
        HambatanActive = false;
    }

    private void FixedUpdate()
    {
        if(TimerInterval >= 0) 
        {
            TimerInterval -= Time.deltaTime;
        }
        else 
        {
            if (!HambatanActive)
            {
                var RandomHambatan = Random.Range(0, JumlahHambatan);
                SetHambatan(RandomHambatan);
            }
        }

        if (Noice)
        {
            if (NoiceTimer >= 0)
            {
                NoiceTimer -= Time.deltaTime;
            }
            else
            {
                Noice = false;
            }
        }
    }

    public void AddNoice() 
    {
        NoiceTimer = 0.3f;
        Noice = true;
    }

    public void ShootThehose() 
    {
        StartCoroutine(ShootTheHoecoro());
        ShootTheHoe.Invoke();
        FindObjectOfType<AudioManager>().SetCurrentSoundFXClip("waterjet");
    }

    IEnumerator ShootTheHoecoro() 
    {
        yield return new WaitForSeconds(1f);
        AfterShoot.Invoke();
    }
}
