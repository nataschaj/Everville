using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseTheGateSimple : MonoBehaviour {

    //public GameObject coins;
    public GameObject gate;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gate.SetActive(true);
        }
    }
}
