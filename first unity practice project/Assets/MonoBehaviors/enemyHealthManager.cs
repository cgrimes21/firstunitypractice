using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthManager : MonoBehaviour
{

    public int health;
    public int mhealth;


    // Use this for initialization
    void Start()
    {
        health = mhealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);

        }

    }

    public void hurt(int damage)
    {
        health -= damage;
    }

    public void setMaxHealth()
    {
        health = mhealth;

    }
}
