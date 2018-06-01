using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //public int sceneToChangeTo;
    public Transform destination;
    public AudioSource doorSound;
    public float maxXPos;
    public float minXPos;
    public float maxYPos;
    public float minYPos;
    public CameraScript MainCamera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "NonTeleport")
        {
            GameObject cameraObject = null;
            if (other.tag == "Player")
            {

                // Start door sound

                if (doorSound != null)
                {
                    doorSound.Play();
                }
                

                //Boundary Control
                MainCamera.maxXPos = maxXPos;
                MainCamera.maxYPos = maxYPos;
                MainCamera.minXPos = minXPos;
                MainCamera.minYPos = minYPos;

                cameraObject = GameObject.Find("Main Camera");
                cameraObject.transform.position = new Vector3(Mathf.Clamp(destination.position.x,minXPos,maxXPos), Mathf.Clamp(destination.position.y, minYPos, maxYPos)); // destination.position;
                other.transform.position = destination.position;

                var playerScript = other.GetComponent<PlayerMovement>();
                playerScript.StopWalking();
            }
            else
                other.transform.position = destination.position;

        }
    }
}