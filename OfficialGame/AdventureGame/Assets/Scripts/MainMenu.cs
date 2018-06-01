using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


public class MainMenu : MonoBehaviour {


    private GameObject achButton;
    private GameObject ldrButton;

    void Start()
    {
        
        //starting google play
        if (!Social.localUser.authenticated)
            Social.localUser.Authenticate((bool success) =>
            {

            });

        achButton = GameObject.Find("achButton");
        ldrButton = GameObject.Find("ldrButton");
        //PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
    }

    public void Update()
    {
        //achButton.SetActive(Social.localUser.authenticated);
        //ldrButton.SetActive(Social.localUser.authenticated);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Achievement()
    {
        Social.ShowAchievementsUI();
    }

    public void QuitGame()
    {
        Debug.Log("GUIT");
        Application.Quit();
    }

    public void ShowAchievements()
    {


        PlayGamesPlatform.Instance.ShowAchievementsUI();
        //if (PlayGamesPlatform.Instance.localUser.authenticated)
        //{
        //    PlayGamesPlatform.Instance.ShowAchievementsUI();
        //}
        //else
        //{
        //    Debug.Log("Cannot show Achievements, not logged in");
        //}
    }
    public void ShowLeaderboards()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Debug.Log("Cannot show leaderboard: not authenticated");
        }
    }
}
