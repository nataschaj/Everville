using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDialog : MonoBehaviour
{
    public Text finishedQuestCount;
    public int questCount;

    public int questNumber;
    public int finishedQuestNumber;
    public string[] BeforeQuestLines;
    public string[] StartQuestLines;
    public string[] DuringQuestLines;
    public string[] FinishQuestLines;
    public string[] AfterQuestLines;
    public GameObject ItemNeeded;
    public GameObject ItemReward;
    private NPCDialog dialog;
    private PlayerMovement playerScript;
    private string currentDialog;
    private bool finishedCurrentDialog;

    // Use this for initialization
    void Start()
    {
        dialog = gameObject.GetComponent<NPCDialog>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.currentQuest < questNumber - 1)
        {
            dialog.dialogLines = BeforeQuestLines;
            currentDialog = "before";
        }
        else if (playerScript.currentQuest == questNumber - 1)

        {
            dialog.dialogLines = StartQuestLines;
            currentDialog = "start";
        }
        //else if (playerScript.currentQuest > finishedQuestNumber)
        //{
        //    dialog.dialogLines = AfterQuestLines;
        //    currentDialog = "after";
        //}

        //Debug.Log(finishedCurrentDialog);
        if (dialog.currentLine > 0 && dialog.currentLine < dialog.dialogLines.Length - 1)
        {
            finishedCurrentDialog = false;
        }
        else if (dialog.currentLine == dialog.dialogLines.Length - 1)
        {
            finishedCurrentDialog = true;
        }

        if (dialog.currentLine == -1 && finishedCurrentDialog)
        {
            finishedCurrentDialog = false;
            if (playerScript.currentQuest == questNumber - 1 )
            { // End of dialog and quest before this one means ready to recieve new quest.
                playerScript.currentQuest = questNumber;
                dialog.dialogLines = DuringQuestLines;
                currentDialog = "during";
            }

            if (currentDialog == "finish")
            {
                //After quest is completed
                playerScript.gameObject.GetComponent<Inventory>().RemoveItem(ItemNeeded);
                dialog.dialogLines = AfterQuestLines;
                currentDialog = "after";

                if (ItemReward != null)
                {
                    playerScript.gameObject.GetComponent<Inventory>().AddItem(ItemReward);
                }
                playerScript.currentQuest = finishedQuestNumber;
            }
        }

        if ( playerScript.gameObject.GetComponent<Inventory>().FindItem(ItemNeeded) && currentDialog == "during")
        {
            // Quest completed!

            dialog.dialogLines = FinishQuestLines;
            finishedCurrentDialog = false;
            currentDialog = "finish";
        }

        
    }
}
