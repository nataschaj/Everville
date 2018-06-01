using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisableDialogButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject Dialog;
    public UnityEngine.UI.Text dialogText;
    public UnityEngine.UI.Button activeButton;

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<Button>().interactable = false;
        //Dialog.SetActive(false);
        GetComponent<Button>().gameObject.SetActive(false);
    }
}