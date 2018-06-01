using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

public class Inventory : MonoBehaviour {

    private GameObject item;
    public Button[] InventoryButtons = new Button[10];  //button array
    public GameObject[] inventory = new GameObject[10]; //gameobject array that has room for 10 items 

   

    #region  AddItem
    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        //first open the slot in the inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null) // looking for an empty spot in inventory
            {
                inventory[i] = item;

                //Update UI
                InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                //Debug.Log(item.name + " was added");
                itemAdded = true;
                //Do something with object
                item.SendMessage("DoInteraction");
                break; //stop running the loop so the item doesn't get added to all the empty slots
            }
        }

        //inventory was full
        if (!itemAdded)
        {
            Debug.Log("Inventory full! Item was not added");
        }
    }
    #endregion

    #region FindItem
    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                //We found the item
                return true;
            }
        }
        //Item not found
        return false;
    }
    #endregion

    #region Find Item By Type
    public GameObject FindItemByType(string itemType)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i]!= null)
            {
                if (inventory[i].GetComponent<InteractionObjects>().itemType == itemType)
                {
                    //We found the item
                    return inventory[i];
                }
            }

            //if (inventory[i].GetComponent<InteractionObjects>().itemType == itemType)
            //{
            //    //We found the item
            //    return inventory[i];
            //}
            if (PlayGamesPlatform.Instance.localUser.authenticated)
            {
                
                if (FindItemByType("Wand"))
                {
                    PlayGamesPlatform.Instance.ReportProgress(
                        GPGSIds.achievement_youre_a_wizard_harry,
                        100.0f, (bool successs) => {
                            Debug.Log("(Everville) You're A Wizard Harry! : " +
                              successs);
                        });
                }
                

            }
        }
        //Item of type not found
        return null;
    }
    #endregion


    #region RemoveItem
    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i]== item)
            {
                //We found the item - Remove it
                inventory[i] = null;
                Debug.Log(item.name + " was removed from inventory");

                //Update UI
                InventoryButtons[i].image.overrideSprite = null;
                break;

                
            }
        }

    }
    #endregion 

    #region RemoveItem at array 0
    public void RemoveItem0()
    {
        if (FindItemByType("Dog"))
        {
            Debug.Log("Dog found in inventory");
            Debug.Log(inventory[0]);
            GetPlayerPosition(inventory[0]);
            inventory[0] = null;
            InventoryButtons[0].image.overrideSprite = null;
            //Debug.Log(inventory[0].name + " was removed from inventory");

            #region IGNORER
            //inventory[0] = item;
            //item = null;
            //Debug.Log(item.name + " was removed from inventory");
            //InventoryButtons[0].image.overrideSprite = null;
            #endregion
        }
        else if (FindItemByType("Potion"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[0]);
            GetPlayerPosition(inventory[0]);
            inventory[0] = null;
            InventoryButtons[0].image.overrideSprite = null;
        }
        else if (FindItemByType("Fruit"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[0]);
            GetPlayerPosition(inventory[0]);
            inventory[0] = null;
            InventoryButtons[0].image.overrideSprite = null;
        }
        else if (FindItemByType("Chicken"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[0]);
            GetPlayerPosition(inventory[0]);
            inventory[0] = null;
            InventoryButtons[0].image.overrideSprite = null;
        }
        else if (FindItemByType("Drumsticks"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[0]);
            GetPlayerPosition(inventory[0]);
            inventory[0] = null;
            InventoryButtons[0].image.overrideSprite = null;
        }
        else if (FindItemByType("Orb"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[0]);
            GetPlayerPosition(inventory[0]);
            inventory[0] = null;
            InventoryButtons[0].image.overrideSprite = null;
        }
        else if (FindItemByType("Wand"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[0]);
            GetPlayerPosition(inventory[0]);
            inventory[0] = null;
            InventoryButtons[0].image.overrideSprite = null;
        }
    }
    #endregion

    #region RemoveItem at array 1
    public void RemoveItem1()
    {
        if (FindItemByType("Dog"))
        {
            Debug.Log("Dog found in inventory");
            Debug.Log(inventory[1]);
            GetPlayerPosition(inventory[1]);
            inventory[1] = null;
            InventoryButtons[1].image.overrideSprite = null;
            //Debug.Log(inventory[0].name + " was removed from inventory");

            #region IGNORER
            //inventory[0] = item;
            //item = null;
            //Debug.Log(item.name + " was removed from inventory");
            //InventoryButtons[0].image.overrideSprite = null;
            #endregion
        }
        else if (FindItemByType("Potion"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[1]);
            GetPlayerPosition(inventory[1]);
            inventory[1] = null;
            InventoryButtons[1].image.overrideSprite = null;
        }
        else if (FindItemByType("Fruit"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[1]);
            GetPlayerPosition(inventory[1]);
            inventory[1] = null;
            InventoryButtons[1].image.overrideSprite = null;
        }
        else if (FindItemByType("Chicken"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[1]);
            GetPlayerPosition(inventory[1]);
            inventory[1] = null;
            InventoryButtons[1].image.overrideSprite = null;
        }
        else if (FindItemByType("Drumsticks"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[1]);
            GetPlayerPosition(inventory[1]);
            inventory[1] = null;
            InventoryButtons[1].image.overrideSprite = null;
        }
        else if (FindItemByType("Orb"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[1]);
            GetPlayerPosition(inventory[1]);
            inventory[1] = null;
            InventoryButtons[1].image.overrideSprite = null;
        }
        else if (FindItemByType("Wand"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[1]);
            GetPlayerPosition(inventory[1]);
            inventory[1] = null;
            InventoryButtons[1].image.overrideSprite = null;
        }
    }
    #endregion

    #region RemoveItem at array 2
    public void RemoveItem2()
    {
        if (FindItemByType("Dog"))
        {
            Debug.Log("Dog found in inventory");
            Debug.Log(inventory[2]);
            GetPlayerPosition(inventory[2]);
            inventory[2] = null;
            InventoryButtons[2].image.overrideSprite = null;
            //Debug.Log(inventory[0].name + " was removed from inventory");

            #region IGNORER
            //inventory[0] = item;
            //item = null;
            //Debug.Log(item.name + " was removed from inventory");
            //InventoryButtons[0].image.overrideSprite = null;
            #endregion
        }
        else if (FindItemByType("Potion"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[2]);
            GetPlayerPosition(inventory[2]);
            inventory[2] = null;
            InventoryButtons[2].image.overrideSprite = null;
        }
        else if (FindItemByType("Fruit"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[2]);
            GetPlayerPosition(inventory[2]);
            inventory[2] = null;
            InventoryButtons[2].image.overrideSprite = null;
        }
        else if (FindItemByType("Chicken"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[2]);
            GetPlayerPosition(inventory[2]);
            inventory[2] = null;
            InventoryButtons[2].image.overrideSprite = null;
        }
        else if (FindItemByType("Drumsticks"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[2]);
            GetPlayerPosition(inventory[2]);
            inventory[2] = null;
            InventoryButtons[2].image.overrideSprite = null;
        }
        else if (FindItemByType("Orb"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[2]);
            GetPlayerPosition(inventory[2]);
            inventory[2] = null;
            InventoryButtons[2].image.overrideSprite = null;
        }
        else if (FindItemByType("Wand"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[2]);
            GetPlayerPosition(inventory[2]);
            inventory[2] = null;
            InventoryButtons[2].image.overrideSprite = null;
        }
    }
    #endregion

    #region RemoveItem at array 3
    public void RemoveItem3()
    {
        if (FindItemByType("Dog"))
        {
            Debug.Log("Dog found in inventory");
            Debug.Log(inventory[3]);
            GetPlayerPosition(inventory[3]);
            inventory[3] = null;
            InventoryButtons[3].image.overrideSprite = null;
            //Debug.Log(inventory[0].name + " was removed from inventory");

            #region IGNORER
            //inventory[0] = item;
            //item = null;
            //Debug.Log(item.name + " was removed from inventory");
            //InventoryButtons[0].image.overrideSprite = null;
            #endregion
        }
        else if (FindItemByType("Potion"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[3]);
            GetPlayerPosition(inventory[3]);
            inventory[3] = null;
            InventoryButtons[3].image.overrideSprite = null;
        }
        else if (FindItemByType("Fruit"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[3]);
            GetPlayerPosition(inventory[3]);
            inventory[3] = null;
            InventoryButtons[3].image.overrideSprite = null;
        }
        else if (FindItemByType("Chicken"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[3]);
            GetPlayerPosition(inventory[3]);
            inventory[3] = null;
            InventoryButtons[3].image.overrideSprite = null;
        }
        else if (FindItemByType("Drumsticks"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[3]);
            GetPlayerPosition(inventory[3]);
            inventory[3] = null;
            InventoryButtons[3].image.overrideSprite = null;
        }
        else if (FindItemByType("Orb"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[3]);
            GetPlayerPosition(inventory[3]);
            inventory[3] = null;
            InventoryButtons[3].image.overrideSprite = null;
        }
        else if (FindItemByType("Wand"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[3]);
            GetPlayerPosition(inventory[3]);
            inventory[3] = null;
            InventoryButtons[3].image.overrideSprite = null;
        }
    }
    #endregion

    #region RemoveItem at array 4
    public void RemoveItem4()
    {
        if (FindItemByType("Dog"))
        {
            Debug.Log("Dog found in inventory");
            Debug.Log(inventory[4]);
            GetPlayerPosition(inventory[40]);
            inventory[4] = null;
            InventoryButtons[4].image.overrideSprite = null;
            //Debug.Log(inventory[0].name + " was removed from inventory");

            #region IGNORER
            //inventory[0] = item;
            //item = null;
            //Debug.Log(item.name + " was removed from inventory");
            //InventoryButtons[0].image.overrideSprite = null;
            #endregion
        }
        else if (FindItemByType("Potion"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[4]);
            GetPlayerPosition(inventory[40]);
            inventory[4] = null;
            InventoryButtons[4].image.overrideSprite = null;
        }
        else if (FindItemByType("Fruit"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[4]);
            GetPlayerPosition(inventory[40]);
            inventory[4] = null;
            InventoryButtons[4].image.overrideSprite = null;
        }
        else if (FindItemByType("Chicken"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[4]);
            GetPlayerPosition(inventory[40]);
            inventory[4] = null;
            InventoryButtons[4].image.overrideSprite = null;
        }
        else if (FindItemByType("Drumsticks"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[4]);
            GetPlayerPosition(inventory[40]);
            inventory[4] = null;
            InventoryButtons[4].image.overrideSprite = null;
        }
        else if (FindItemByType("Orb"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[4]);
            GetPlayerPosition(inventory[4]);
            inventory[4] = null;
            InventoryButtons[4].image.overrideSprite = null;
        }
        else if (FindItemByType("Wand"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[4]);
            GetPlayerPosition(inventory[4]);
            inventory[4] = null;
            InventoryButtons[4].image.overrideSprite = null;
        }
    }
    #endregion

    #region RemoveItem at array 5
    public void RemoveItem5()
    {
        if (FindItemByType("Dog"))
        {
            Debug.Log("Dog found in inventory");
            Debug.Log(inventory[5]);
            GetPlayerPosition(inventory[5]);
            inventory[5] = null;
            InventoryButtons[5].image.overrideSprite = null;
            //Debug.Log(inventory[0].name + " was removed from inventory");

            #region IGNORER
            //inventory[0] = item;
            //item = null;
            //Debug.Log(item.name + " was removed from inventory");
            //InventoryButtons[0].image.overrideSprite = null;
            #endregion
        }
        else if (FindItemByType("Potion"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[5]);
            GetPlayerPosition(inventory[5]);
            inventory[5] = null;
            InventoryButtons[5].image.overrideSprite = null;
        }
        else if (FindItemByType("Fruit"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[5]);
            GetPlayerPosition(inventory[5]);
            inventory[5] = null;
            InventoryButtons[5].image.overrideSprite = null;
        }
        else if (FindItemByType("Chicken"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[5]);
            GetPlayerPosition(inventory[5]);
            inventory[5] = null;
            InventoryButtons[5].image.overrideSprite = null;
        }
        else if (FindItemByType("Drumsticks"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[5]);
            GetPlayerPosition(inventory[5]);
            inventory[5] = null;
            InventoryButtons[5].image.overrideSprite = null;
        }
        else if (FindItemByType("Orb"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[5]);
            GetPlayerPosition(inventory[5]);
            inventory[5] = null;
            InventoryButtons[5].image.overrideSprite = null;
        }
        else if (FindItemByType("Wand"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[5]);
            GetPlayerPosition(inventory[5]);
            inventory[5] = null;
            InventoryButtons[5].image.overrideSprite = null;
        }
    }
    #endregion

    #region RemoveItem at array 6
    public void RemoveItem6()
    {
        if (FindItemByType("Dog"))
        {
            Debug.Log("Dog found in inventory");
            Debug.Log(inventory[6]);
            GetPlayerPosition(inventory[6]);
            inventory[6] = null;
            InventoryButtons[6].image.overrideSprite = null;
            //Debug.Log(inventory[0].name + " was removed from inventory");

            #region IGNORER
            //inventory[0] = item;
            //item = null;
            //Debug.Log(item.name + " was removed from inventory");
            //InventoryButtons[0].image.overrideSprite = null;
            #endregion
        }
        else if (FindItemByType("Potion"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[6]);
            GetPlayerPosition(inventory[6]);
            inventory[6] = null;
            InventoryButtons[6].image.overrideSprite = null;
        }
        else if (FindItemByType("Fruit"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[6]);
            GetPlayerPosition(inventory[6]);
            inventory[6] = null;
            InventoryButtons[6].image.overrideSprite = null;
        }
        else if (FindItemByType("Chicken"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[6]);
            GetPlayerPosition(inventory[6]);
            inventory[6] = null;
            InventoryButtons[6].image.overrideSprite = null;
        }
        else if (FindItemByType("Drumsticks"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[6]);
            GetPlayerPosition(inventory[6]);
            inventory[6] = null;
            InventoryButtons[6].image.overrideSprite = null;
        }
        else if (FindItemByType("Orb"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[6]);
            GetPlayerPosition(inventory[6]);
            inventory[6] = null;
            InventoryButtons[6].image.overrideSprite = null;
        }
        else if (FindItemByType("Wand"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[6]);
            GetPlayerPosition(inventory[6]);
            inventory[6] = null;
            InventoryButtons[6].image.overrideSprite = null;
        }
    }
    #endregion

    #region RemoveItem at array 7
    public void RemoveItem7()
    {
        if (FindItemByType("Dog"))
        {
            Debug.Log("Dog found in inventory");
            Debug.Log(inventory[7]);
            GetPlayerPosition(inventory[7]);
            inventory[7] = null;
            InventoryButtons[7].image.overrideSprite = null;
            //Debug.Log(inventory[0].name + " was removed from inventory");

            #region IGNORER
            //inventory[0] = item;
            //item = null;
            //Debug.Log(item.name + " was removed from inventory");
            //InventoryButtons[0].image.overrideSprite = null;
            #endregion
        }
        else if (FindItemByType("Potion"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[7]);
            GetPlayerPosition(inventory[7]);
            inventory[7] = null;
            InventoryButtons[7].image.overrideSprite = null;
        }
        else if (FindItemByType("Fruit"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[7]);
            GetPlayerPosition(inventory[7]);
            inventory[7] = null;
            InventoryButtons[7].image.overrideSprite = null;
        }
        else if (FindItemByType("Chicken"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[7]);
            GetPlayerPosition(inventory[7]);
            inventory[7] = null;
            InventoryButtons[7].image.overrideSprite = null;
        }
        else if (FindItemByType("Drumsticks"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[7]);
            GetPlayerPosition(inventory[7]);
            inventory[7] = null;
            InventoryButtons[7].image.overrideSprite = null;
        }
        else if (FindItemByType("Orb"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[7]);
            GetPlayerPosition(inventory[7]);
            inventory[7] = null;
            InventoryButtons[7].image.overrideSprite = null;
        }
        else if (FindItemByType("Wand"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[7]);
            GetPlayerPosition(inventory[7]);
            inventory[7] = null;
            InventoryButtons[7].image.overrideSprite = null;
        }
    }
    #endregion

    #region RemoveItem at array 8
    public void RemoveItem8()
    {
        if (FindItemByType("Dog"))
        {
            Debug.Log("Dog found in inventory");
            Debug.Log(inventory[8]);
            GetPlayerPosition(inventory[8]);
            inventory[8] = null;
            InventoryButtons[8].image.overrideSprite = null;
            //Debug.Log(inventory[0].name + " was removed from inventory");

            #region IGNORER
            //inventory[0] = item;
            //item = null;
            //Debug.Log(item.name + " was removed from inventory");
            //InventoryButtons[0].image.overrideSprite = null;
            #endregion
        }
        else if (FindItemByType("Potion"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[8]);
            GetPlayerPosition(inventory[8]);
            inventory[8] = null;
            InventoryButtons[8].image.overrideSprite = null;
        }
        else if (FindItemByType("Fruit"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[8]);
            GetPlayerPosition(inventory[8]);
            inventory[8] = null;
            InventoryButtons[8].image.overrideSprite = null;
        }
        else if (FindItemByType("Chicken"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[8]);
            GetPlayerPosition(inventory[8]);
            inventory[8] = null;
            InventoryButtons[8].image.overrideSprite = null;
        }
        else if (FindItemByType("Drumsticks"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[8]);
            GetPlayerPosition(inventory[8]);
            inventory[8] = null;
            InventoryButtons[8].image.overrideSprite = null;
        }
        else if (FindItemByType("Orb"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[8]);
            GetPlayerPosition(inventory[8]);
            inventory[8] = null;
            InventoryButtons[8].image.overrideSprite = null;
        }
        else if (FindItemByType("Wand"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[8]);
            GetPlayerPosition(inventory[8]);
            inventory[8] = null;
            InventoryButtons[8].image.overrideSprite = null;
        }
    }
    #endregion

    #region RemoveItem at array 9
    public void RemoveItem9()
    {
        if (FindItemByType("Dog"))
        {
            Debug.Log("Dog found in inventory");
            Debug.Log(inventory[9]);
            GetPlayerPosition(inventory[9]);
            inventory[9] = null;
            InventoryButtons[9].image.overrideSprite = null;
            //Debug.Log(inventory[0].name + " was removed from inventory");

            #region IGNORER
            //inventory[0] = item;
            //item = null;
            //Debug.Log(item.name + " was removed from inventory");
            //InventoryButtons[0].image.overrideSprite = null;
            #endregion
        }
        else if (FindItemByType("Potion"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[9]);
            GetPlayerPosition(inventory[9]);
            inventory[9] = null;
            InventoryButtons[9].image.overrideSprite = null;
        }
        else if (FindItemByType("Fruit"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[90]);
            GetPlayerPosition(inventory[9]);
            inventory[9] = null;
            InventoryButtons[9].image.overrideSprite = null;
        }
        else if (FindItemByType("Chicken"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[9]);
            GetPlayerPosition(inventory[9]);
            inventory[9] = null;
            InventoryButtons[9].image.overrideSprite = null;
        }
        else if (FindItemByType("Drumsticks"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[9]);
            GetPlayerPosition(inventory[9]);
            inventory[9] = null;
            InventoryButtons[9].image.overrideSprite = null;
        }
        else if (FindItemByType("Orb"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[9]);
            GetPlayerPosition(inventory[9]);
            inventory[9] = null;
            InventoryButtons[9].image.overrideSprite = null;
        }
        else if (FindItemByType("Wand"))
        {
            Debug.Log("Potion found in inventory");
            Debug.Log(inventory[9]);
            GetPlayerPosition(inventory[9]);
            inventory[9] = null;
            InventoryButtons[9].image.overrideSprite = null;
        }
    }
    #endregion

    #region Drop item at players current position
    //til drop item
    public void GetPlayerPosition(GameObject item)
    {
        item.SetActive(true);

        var player = GameObject.FindGameObjectWithTag("Player");
        var pos = player.transform.position;
        if (item)
        {
            Vector3 temp = new Vector3(pos.x, pos.y - 20, pos.z);
            item.transform.position = temp;
        }
        Debug.Log(pos);
    }
    #endregion
}
