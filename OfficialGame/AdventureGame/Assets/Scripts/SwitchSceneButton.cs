using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchSceneButton : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private string newLevel;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(newLevel);
        if (newLevel == "HomeOutside")
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            Vector3 temp = new Vector3(1585, -1206, 0);
            player.transform.position = temp;
        }
    }
}
