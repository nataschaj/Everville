using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    //// Use this for initialization
    //void Start () {
    //       PlayGamesPlatform.Activate();
    //       PlayGamesPlatform.DebugLogEnabled = true;
    //   }

    //// Update is called once per frame
    //void Update () {

    //}

    public Text UId;
    // Use this for initialization
    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        LogIn();
    }

    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("login success");
                Debug.Log(Social.localUser.id);
                Debug.Log(Social.localUser.userName);
                UId.text = Social.localUser.id;


                    PlayGamesPlatform.Instance.ReportProgress(
                        GPGSIds.achievement_login,
                        100.0f, (bool successs) => {
                            Debug.Log("(Everville) Welcome Unlock: " +
                              successs);
                        });
            }
            else
            {
                Debug.Log("login fail");
            }

        });
    }

    public void LogOut()
    {
        Debug.Log("LogOut");
        ((PlayGamesPlatform)Social.Active).SignOut();
    }

    public void ShowAchievements()
    {


        //PlayGamesPlatform.Instance.ShowAchievementsUI();
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
        else
        {
            Debug.Log("Cannot show Achievements, not logged in");
        }
    }
}
