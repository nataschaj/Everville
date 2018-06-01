using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region KeyboardMovement
    //Rigidbody2D rBody;
    //Animator anim;
    //public float speed;

    //// Use this for initialization
    //void Start()
    //{

    //    rBody = GetComponent<Rigidbody2D>();
    //    anim = GetComponent<Animator>();

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    //    if (movementVector != Vector2.zero)
    //    {
    //        anim.SetBool("iswalking", true);
    //        anim.SetFloat("input_x", movementVector.x);
    //        anim.SetFloat("input_y", movementVector.y);
    //    }
    //    else
    //    {
    //        anim.SetBool("iswalking", false);
    //    }

    //    rBody.MovePosition(rBody.position + movementVector * speed * Time.deltaTime);
    //}
    #endregion

    public Animator animator;
    public Vector3 target = new Vector3();
    public Vector3 direction = new Vector3();
    public Vector3 position = new Vector3();
    public float speed = 2.0f;
    public bool isTalking;
    public int currentQuest = 0;
    private int fingerID;

    private GameObject startDialog;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        startDialog = GameObject.Find("Start Dialog");
        //fingerID is used to check for EventSystem clicks (HUD Elements). - 1 for mouse and 0 for android touch.

        fingerID = 0;
        if (Application.isEditor) //Run through Unity, therefore change to use mouse.
        {
            Debug.Log("Changed to editormode - mouse works now.");
            fingerID = -1;
        }

    }

    void Update()
    {

        position = gameObject.transform.position;

        if (!isTalking && Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(fingerID))
        {
            if (startDialog.activeSelf)
            {
                startDialog.SetActive(false);
            }
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
        }

        //if (target != Vector3.zero && (target - position).magnitude >= .06 && !HasStopped)
        if (target != Vector3.zero && (target - position).magnitude >= 1)
        {
            direction = (target - position).normalized;
            gameObject.transform.position += direction * speed * Time.deltaTime;
            animator.SetBool("iswalking", true);
            animator.SetFloat("input_x", direction.x);
            animator.SetFloat("input_y", direction.y);
        }
        else
        {
            target = Vector3.zero;
            animator.SetBool("iswalking", false);
        }
    }

    public void StopWalking()
    {
        target = Vector3.zero;
        animator.SetBool("iswalking", false);
    }


    //When inside the NPC/Objects' Collider
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "talkingNPC")
        {
            StopWalking();
            var dialogScript = other.GetComponent<NPCDialog>();
            dialogScript.CloseEnoughToTalk = true;
        }

        else if (other.tag == "interObject")
        {
            StopWalking();
            var dialogScript = other.GetComponent<InteractionObjects>();
            dialogScript.CloseEnoughToPickup = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        StopWalking();
    }
    public void OnCollisionStay2D(Collision2D coll)
    {
        StopWalking();
    }


    //When outside the NPC/Objects' collider
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "talkingNPC")
        {
            var dialogScript = other.GetComponent<NPCDialog>();
            dialogScript.CloseEnoughToTalk = false;
        }
        else if (other.tag == "interObject")
        {
            StopWalking();
            var dialogScript = other.GetComponent<InteractionObjects>();
            dialogScript.CloseEnoughToPickup = false;
        }
    }
}
