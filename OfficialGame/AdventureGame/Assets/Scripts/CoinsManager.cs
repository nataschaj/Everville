using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour {


    private int count;
    public Text countText;
    public Text gameoverText;
    public Text scoreText;
    public GameObject dialog;
    public Text highscoreText;
    public Text UIHighscoreText;
    private int highscore;
    Text text;

    void Start()
    {

        text = GetComponent<Text>();
        highscore = PlayerPrefs.GetInt("UIHighscoreText", highscore);
        count = 0;
        SetCountText();
        gameoverText.text = "";
        scoreText.text = "";
        highscoreText.text = "";
        UIHighscoreText.text = "";
    }

    void Update()
    {
        if (count > highscore)
        {
            highscore = count;
            text.text = "" + count;
            PlayerPrefs.SetInt("highscore", highscore);
            
        }
        UIHighscoreText.text = "HIGHSCORE: " + highscore;
        PlayerPrefs.Save();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            count = count += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "COINS: " + count.ToString();
        if (count >= 6)
        {
            dialog.SetActive(true);
            gameoverText.text = "GAME OVER!";
            scoreText.text = "YOUR SCORE: " + count;
            highscoreText.text = "HIGHSCORE: " + highscore;
            

        }
        PlayerPrefs.Save();
    }
}
