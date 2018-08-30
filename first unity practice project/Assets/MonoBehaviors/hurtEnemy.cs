using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtEnemy : MonoBehaviour {


    public int damage;
    public GameObject blood_splatter;
    public Transform hitpoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemyHealthManager>().hurt(damage);
            Instantiate(blood_splatter, hitpoint.position, hitpoint.rotation);

        }

    }
}
