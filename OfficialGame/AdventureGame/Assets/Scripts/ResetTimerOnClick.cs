using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResetTimerOnClick : MonoBehaviour, IPointerClickHandler
{

    private TimerScript time;
    public GameObject timer;
    //public GameObject coins;
    private SpawnCoins spawnScript;
    private SumScoreExample reset;

    public void OnPointerClick(PointerEventData eventData)
    {
        //coins.SetActive(true);
        timer.SetActive(true);
        //coins.SetActive(true);

        //time.timer = 60;
        //if (coins.active = false)
        //{
        //    coins.SetActive(true);
        //}
    }
}
