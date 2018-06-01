using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    Animator anim;
    public float speed;

    //Movement
    public float walkTimeMin;
    public float walkTimeMax;
    public float walkCounter;
    public float waitTime;
    public float waitCounter;

    //Animation
    public Vector2 facing;

    private int WalkDirection;
    public bool isWalking;
    private int blockedDirection;
    public bool IsTalking;

    //private bool onBlockingTrigger;

    // Use this for initialization
    void Start()
    {
        blockedDirection = -1;
        //rBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        IsTalking = false;
        waitCounter = waitTime;
        walkCounter = Random.Range(walkTimeMin, walkTimeMax);

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("iswalking", isWalking);

        if (isWalking && !IsTalking)
        {
            walkCounter -= Time.deltaTime;

            switch (WalkDirection)
            {
                //case 0:
                //    rBody.velocity = new Vector2(0, speed);
                //    break;
                //case 1:
                //    rBody.velocity = new Vector2(speed, 0);
                //    break;
                //case 2:
                //    rBody.velocity = new Vector2(0, -speed);
                //    break;
                //case 3:
                //    rBody.velocity = new Vector2(-speed, 0);
                //    break;

                case 0:
                    //rBody.velocity = new Vector2(0, speed);
                    transform.position += Vector3.up * speed * Time.deltaTime;
                    facing.y = 1;
                    facing.x = 0;
                    break;

                case 1:
                    //rBody.velocity = new Vector2(speed, 0);
                    transform.position += Vector3.right * speed * Time.deltaTime;
                    facing.x = 1;
                    facing.y = 0;
                    //transform.localScale = new Vector3(6f, 6f, 1f);
                    break;

                case 2:
                    //rBody.velocity = new Vector2(0, -speed);
                    transform.position += Vector3.down * speed * Time.deltaTime;
                    facing.y = -1;
                    facing.x = 0;
                    break;

                case 3:
                    //rBody.velocity = new Vector2(-speed, 0);
                    transform.position += Vector3.left * speed * Time.deltaTime;
                    facing.y = 0;
                    facing.x = -1;
                    //transform.localScale = new Vector3(-6f, 6f, 1f);

                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        }
        else if (!IsTalking)
        {
            waitCounter -= Time.deltaTime;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }

        //Facing Animation
        anim.SetFloat("input_x", facing.x);
        anim.SetFloat("input_y", facing.y);

    }

    public void SetFacingPosition(Vector3 target)
    {
        var direction = (target - transform.position).normalized;
        facing.x = direction.x;
        facing.y = direction.y;

        //Facing Animation
        anim.SetFloat("input_x", facing.x);
        anim.SetFloat("input_y", facing.y);
    }
    public void ChooseDirection()
    {
        if (blockedDirection > -1)
        {

            switch (blockedDirection)
            {
                case 0:
                    WalkDirection = 2;
                    break;
                case 1:
                    WalkDirection = 3;
                    break;
                case 2:
                    WalkDirection = 0;
                    break;
                case 3:
                    WalkDirection = 1;
                    break;
            }
            blockedDirection = -1;
        }
        else
        {
            WalkDirection = Random.Range(0, 4);
        }

        isWalking = true;
        walkCounter = Random.Range(walkTimeMin, walkTimeMax);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        walkCounter = -1;
        blockedDirection = WalkDirection;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NpcCollider")
        {
            walkCounter = -1;
            blockedDirection = WalkDirection;
            //onBlockingTrigger = true;
        }
    }
}
