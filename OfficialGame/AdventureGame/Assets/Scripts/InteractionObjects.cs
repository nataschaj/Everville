using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObjects : MonoBehaviour
{


    public string itemType; //This will tell what type of item this object is. Declare this in unity, eg. Health Potion
    public bool talks;      //if true, then the object can talk to the player
    public Animator anim;   //Drag the animator to this property in unity
    public bool inventory;  //if true, this object can be stored in inventory
    public bool openable;   //if true, this object can be opened
    public bool locked;     //if true, then the object is locked
    public GameObject itemNeeded;   //item needed in order to interact with this item. Example drag a key in unity to this property, so the game knows that
                                    //this item is needed in order to do something. 

    //Dialogue box for interactable item
    public bool CloseEnoughToPickup;
    //public float maxPickupDistance;
    public GameObject Dialog;
    public UnityEngine.UI.Text dialogText;
    public UnityEngine.UI.Button activateButton;
    public string[] dialogLines;
    private int currentLine;
    private PlayerMovement playerScript;
    private float originalTriggerRadius;
    private string originalTag;
    public AudioSource tapSound;

    void Start()
    {
        currentLine = -1;
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        originalTriggerRadius = gameObject.GetComponent<CircleCollider2D>().radius;
        originalTag = tag;
    }

    void Update()
    {

        if (CloseEnoughToPickup && currentLine > -1)
        {
            Dialog.SetActive(true);
            activateButton.gameObject.SetActive(true);
            dialogText.text = dialogLines[currentLine];
        }

    }

    public void StopInteraction()
    {
        //Used to force stop conversation.

        currentLine = -1;
    }

    public void DoInteraction()
    {
        //Picked up and put in inventory
        gameObject.SetActive(false);
        Dialog.SetActive(false);
        playerScript.isTalking = false;
        //Debug.Log("Picked Up: " + gameObject.name);
    }

    public void Open()
    {
        anim.SetBool("open", true);
    }

    public void Talk()
    {
        OnMouseOver();
    }

    void OnMouseOver()
    {
        if (enabled)
        {
            if (talks == true)
            {

                if (Input.GetMouseButtonDown(0) && CloseEnoughToPickup && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    if (tapSound != null)
                    {
                        tapSound.Play();
                    }

                    if (currentLine == dialogLines.Length - 1)
                    {
                        // Current dialog is last
                        var npcMove = gameObject.GetComponent<NPCMovement>();
                        if (npcMove != null)
                        {
                            npcMove.IsTalking = false;
                            //npcMove.isWalking = true;
                        }
                        playerScript.isTalking = false;
                        currentLine = -1;
                        // Stop dialog
                        Dialog.SetActive(false);
                        activateButton.gameObject.SetActive(false);
                        tag = originalTag;
                        gameObject.GetComponent<CircleCollider2D>().radius = originalTriggerRadius;
                    }
                    else
                    {
                        // During dialog
                        tag = "NonTeleport";
                        //gameObject.GetComponent<CircleCollider2D>().radius = 1000;
                        var npcMove = gameObject.GetComponent<NPCMovement>();
                        if (npcMove != null)
                        {
                            npcMove.IsTalking = true;
                            npcMove.isWalking = false;

                            npcMove.SetFacingPosition(playerScript.gameObject.transform.position);

                        }
                        playerScript.isTalking = true;
                        currentLine++;
                    }

                }

            }
        }
        

    }

    public void ButtonClick()
    {
        DoInteraction();
    }


}