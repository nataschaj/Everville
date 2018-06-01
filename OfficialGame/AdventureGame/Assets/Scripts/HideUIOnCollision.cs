using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HideUIOnCollision : MonoBehaviour {

    public GameObject inventoryPanel;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inventoryPanel.SetActive(false);
        }
    }
}
