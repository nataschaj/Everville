using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CloseGateonCollision : MonoBehaviour {

    public GameObject gate;
    public GameObject timer;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gate.SetActive(true);
            timer.SetActive(false);
        }
    }
}
