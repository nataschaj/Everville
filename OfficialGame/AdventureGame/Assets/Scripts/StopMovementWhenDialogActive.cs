using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovementWhenDialogActive : MonoBehaviour {

    public GameObject dialog;
    private PlayerMovement movementScript;

	// Use this for initialization
	void Start () {
        if (dialog.active)
        {
            movementScript.StopWalking();
        }
    }
	
	// Update is called once per frame
	void Update () {



    }
}
