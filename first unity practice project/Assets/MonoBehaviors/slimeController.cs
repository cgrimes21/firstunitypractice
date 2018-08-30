using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class slimeController : MonoBehaviour {

    public float moveSpeed;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;

    public float timeToMove;
    public float waitToReload;
    private bool reloading;
    private GameObject theplayer;

    private Rigidbody2D myrigidbody;
    private bool moving;
    private Vector3 moveDirection;


	// Use this for initialization
	void Start () {

        myrigidbody = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

	}
	
	// Update is called once per frame
	void Update () {
		
        if(reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                theplayer.SetActive(true);
                reloading = false;

            }

        }

        if(moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myrigidbody.velocity = moveDirection;
            if(timeToMoveCounter <= 0)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else {
            timeBetweenMoveCounter -= Time.deltaTime;
            myrigidbody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter <= 0)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f,1f) * moveSpeed ,Random.Range(-1f,1f) * moveSpeed, 0f);

            }
        }

	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        /*if(other.gameObject.name == "player")
        {
            other.gameObject.SetActive(false);
            reloading = true;
            theplayer = other.gameObject;
        }
        */
    }
}
