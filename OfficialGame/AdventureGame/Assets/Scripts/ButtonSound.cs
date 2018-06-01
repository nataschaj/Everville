using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class ButtonSound : MonoBehaviour {

    public AudioClip thisAudio;

    public void CheckDetectedMouse()
    {
        OnMouseEnter();
    }

    void OnMouseEnter()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(thisAudio);
        //Debug.Log("mouse detected");
    }
}
