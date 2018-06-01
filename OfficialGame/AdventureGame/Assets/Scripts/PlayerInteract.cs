using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    //current object we can interact with
    public GameObject currentInterObj = null;
    public InteractionObjects currentInterObjScript = null;
    public Inventory inventory;
    public GameObject dialog;
    

    void Update()
    {
        #region SECTION: INTERACTION
        if (Input.GetButtonDown("Interact") && currentInterObj && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            #region SECTION: INVENTORY
            //Check to see if this object is to be stored in inventory
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
            }
            #endregion
            #region SECTION: OPENABLE OBJECTS
            //Check to see if this object can be opened
            if (currentInterObjScript.openable)
            {
                //Check to see if the object is locked
                if (currentInterObjScript.locked)
                {
                    //Check to see is we have the object needed to unlock
                    //Search the inventory for the item needed - if found, unlock object
                    if (inventory.FindItem(currentInterObjScript.itemNeeded))
                    {
                        //We found the item needed
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObj.name + " was unlocked");
                    }
                    else
                    {
                        Debug.Log(currentInterObj.name + " was not unlocked");
                    }
                }
                else
                {
                    //Object is not locked - open the object
                    Debug.Log(currentInterObj.name + " is unlocked");
                    currentInterObjScript.Open();
                }
            }
            #endregion
            #region SECTION: TALKING OBJECTS + DO THEY HAVE A MESSAGE?
            if (currentInterObjScript.talks)
            {
                //tell the object to give its message
                currentInterObjScript.Talk();
            }
            #endregion
        }
        #endregion

        #region SECTION: USING ITEMS
        ////Use a potion
        //if (Input.GetButtonDown("Use Potion"))
        //{
        //    //Check inventory for a potion
        //    GameObject potion = inventory.FindItemByType("Health Potion"); //If you said the itemType was a health potion in unity
        //    if (potion != null)
        //    {
        //        //Use the potion - apply its effect

        //        //Remove the potion from inventory
        //    }
            
        //}

        #endregion

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //se hvis objektet er tagget som interObject
        //if (other.gameObject.tag =="interObject")
        //{
        //    Debug.Log(other.gameObject.name);
        //}

        if (other.CompareTag("interObject"))
        {
            //Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObjects>();
        }

        if (other.CompareTag("PortalDoor"))
        {
            Debug.Log("interacting with: " + other.name);
        }

        //For Mini Game
        if (other.CompareTag("Coin"))
        {
            Debug.Log("interacting with: " + other.name);
        }

        if (other.CompareTag("GateKeeper"))
        {
            Debug.Log("interacting with: " + other.name);
            dialog.SetActive(true);
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }

        if (other.CompareTag("GateKeeper"))
        {
            dialog.SetActive(false);
        }
    }
}
