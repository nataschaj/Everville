using UnityEngine;

/// <summary>
/// Examples for usage of SumScore and SumScoreManager
/// </summary>
public class SumScoreExample : MonoBehaviour {

    public AudioSource coinSouns;

	public void AddPoints(int points)
    {
        SumScore.Add(points);
        CheckHighScore();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            if (FindObjectOfType<TimerScript>().timer > 0)
            {
                AddPoints(10);
                coinSouns.Play();
                //Destroy(other.gameObject);
                other.gameObject.SetActive(false);
            }
            //AddPoints(10);
            ////Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            if (FindObjectOfType<TimerScript>().timer <= 0)
            {
                other.gameObject.SetActive(true);
                Debug.Log("Can't pick up. Time's up!");
            }
        }
    }
    /// <summary>Save if current score is greater than high score</summary>
    public void CheckHighScore () {
        if (SumScore.Score > SumScore.HighScore)
            SumScore.SaveHighScore();
    }

    public void ResetPoints()
    {
        SumScore.Reset();
    }

    public void ResetHighscore()
    {
        SumScore.ClearHighScore();
    }

}
