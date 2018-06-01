using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatNPCMovement : MonoBehaviour
{

    //private Rigidbody2D rBody;
    Animator anim;
    public float speed;

    public float walkTime;
    public float walkCounter;
    public float waitTime;
    public float waitCounter;

    //Animation
    public Vector2 facing;

    private int WalkDirection;
    private bool isWalking;
    private int blockedDirection;

    // Use this for initialization
    void Start()
    {
        blockedDirection = -1;
        //rBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();

        waitCounter = waitTime;
        walkCounter = walkTime;

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("iswalking", isWalking);

        if (isWalking/*anim.GetBool("iswalking") == true*/)
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
        else
        {
            waitCounter -= Time.deltaTime;

            //rBody.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }

        //Dunno?
        anim.SetFloat("input_x", facing.x);
        anim.SetFloat("input_y", facing.y);
        //anim.SetBool("iswalking", true);

    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        while (blockedDirection == WalkDirection)
        {
            WalkDirection = Random.Range(0, 4);
        }
        blockedDirection = -1;
        isWalking = true;
        walkCounter = walkTime;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        walkCounter = -1;
        blockedDirection = WalkDirection;
    }
}
