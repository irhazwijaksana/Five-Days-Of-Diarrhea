using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EndlessManager : MonoBehaviour
{
    public int Day = 1;
    public Text Opening;
    public UnityEvent CompleteCondition;

    public void CallTheDay(int day) 
    {
        Day = day;
        Opening.text = "Day " + day;
    }

    public void NextDay() 
    {
        Day = Day + 1;
        FindObjectOfType<savedata>().SaveTheDayNext(Day);
        CompleteCondition.Invoke();
    }
    public void GameOver()
    {
        Day = 1;
        FindObjectOfType<savedata>().SaveTheDayNext(Day);
    }
}
