using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUIOnCollision : MonoBehaviour {

    public GameObject inventoryPanel;
    //public GameObject coins;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inventoryPanel.SetActive(true);
            //coins.SetActive(false);
        }
    }
}
