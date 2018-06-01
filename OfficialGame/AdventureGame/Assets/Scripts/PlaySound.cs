using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{


    public AudioSource enterClip;
    public AudioSource exitClip;
    public AudioClip fadeClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterClip.Play();
        }

        Debug.Log("has entered"); 
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterClip.Stop();
            exitClip.PlayOneShot(fadeClip);
        }

        Debug.Log("has exited");
    }

}
