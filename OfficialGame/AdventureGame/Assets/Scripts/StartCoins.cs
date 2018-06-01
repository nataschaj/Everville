using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartCoins : MonoBehaviour {

    //public GameObject coins;
    public GameObject gatecloser;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //if (coins.active)
            //{
            //    Debug.Log("Coins are active");
            //}
            //coins.SetActive(true);
            gatecloser.SetActive(true);
        }
    }

    public void OnTriggerExit2d()
    {
        gameObject.SetActive(true);
    }
}
