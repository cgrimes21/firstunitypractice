using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {

    public variable health;
    public variable mhealth;


	// Use this for initialization
	void Start () {
        health = mhealth;	
	}
	
	// Update is called once per frame
	void Update () {
		
        if(health.Value <= 0)
        {
            gameObject.SetActive(false);

        }

	}

    public void hurtPlayer(float damage)
    {
        health.ApplyChange(-damage);
    }

    public void setMaxHealth()
    {
        health = mhealth;

    }
}
