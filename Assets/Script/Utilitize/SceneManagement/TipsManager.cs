using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TipsManager : MonoBehaviour
{
    public GameObject TipsManagers;

    public UnityEvent CloseTheTips;

    public void Close() 
    {
        FindObjectOfType<gamemaster>().resume();
        CloseTheTips.Invoke();
        Destroy(TipsManagers);
    }
}
