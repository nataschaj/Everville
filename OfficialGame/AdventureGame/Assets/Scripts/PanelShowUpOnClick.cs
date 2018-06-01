using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelShowUpOnClick : MonoBehaviour, IPointerClickHandler {

    public GameObject Dialog;
    public UnityEngine.UI.Button activeButton;

    public void OnPointerClick(PointerEventData eventData)
    {
        Dialog.SetActive(true);
        activeButton.gameObject.SetActive(true);
    }

}
