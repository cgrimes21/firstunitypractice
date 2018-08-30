//left off on unity rpg #4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

	public Transform interactTransform;
    public float moveSpeed;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;


    private Animator anim;
    public Rigidbody2D myRigidBody;
    private static bool playerExists;

    public bool playerMoving;
    public Vector2 lastMove;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>(); //gets our player's animator component
        myRigidBody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

        playerMoving = false;

        if (!attacking)
        {



            if (Input.GetAxisRaw("Horizontal") != 0)
            {

                //transform.Translate (new Vector3(Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime,0f,0f));
                myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidBody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            }
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                //transform.Translate (new Vector3 (0f,Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") == 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidBody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
            }

        }

        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;

        }
        if(attackTimeCounter <= 0)
        {
            attacking = false;

            anim.SetBool("Attack", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);


    }
}
