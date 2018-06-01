using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    public Text timeText;
    public float timer;//Countdown Timer
    //public GameObject retryMenu; // Set in inspector
    public GameObject finalScore; // Set in inspector
    public GameObject coins;
    public GameObject timerUI;
    bool keepTiming;
    private SpawnCoins spawnScript;
    public GameObject gameOverScreen;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timeText.text = "" + timer.ToString("00:00");

        if (timer < 10)
        {
            timeText.color = Color.red; //Or however you do your color
        }
        if (timer <= 0)
        {
            //retryMenu.SetActive(true);
            // Activate Retry UI
            //Time.timeScale = 0;
            timer = 60;
            coins.SetActive(false);
            timerUI.SetActive(false);
            gameOverScreen.SetActive(true);
            Invoke("ShowGameOverScreen", 5f);
        }
        //if (timer >= 0)
        //{
        //    //GetComponent<SpawnCoins>().InvokeRepeating("Spawn", spawnScript.spawnDelay, spawnScript.spawnTime);
        //    //InvokeRepeating("Spawn", spawnScript.spawnDelay, spawnScript.spawnTime);
        //    coins.SetActive(true);
        //}
        
    }

    void ShowGameOverScreen()
    {
        gameOverScreen.active = false;
    }

    
}
