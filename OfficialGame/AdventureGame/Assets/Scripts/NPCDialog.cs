using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{

    public GameObject Dialog;
    public UnityEngine.UI.Text dialogText;
    public bool CloseEnoughToTalk;
    public string[] dialogLines;
    public int currentLine;
    public PlayerMovement playerScript;
    private float originalTriggerRadius;
    private string originalTag;
    public AudioSource tapSound;


    // Use this for initialization
    void Start()
    {
        currentLine = -1;
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        originalTriggerRadius = gameObject.GetComponent<CircleCollider2D>().radius;
        originalTag = tag;
    }

    // Update is called once per frame
    void Update()
    {
        if(CloseEnoughToTalk && currentLine > -1)
        {
            Dialog.SetActive(true);
            dialogText.text = dialogLines[currentLine];
        }

    }

    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0) && CloseEnoughToTalk)
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
                tag = originalTag;
                gameObject.GetComponent<CircleCollider2D>().radius = originalTriggerRadius;
            }
            else
            {
                // During dialog
                tag = "NonTeleport";
                gameObject.GetComponent<CircleCollider2D>().radius = 1000;
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
