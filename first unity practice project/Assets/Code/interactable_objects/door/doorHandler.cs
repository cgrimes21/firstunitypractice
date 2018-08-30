using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class doorHandler : MonoBehaviour {

    public enum ActivationType
    {
        ItemCount, ItemMass

    }
    public Animator anim;
    public BoxCollider2D col;
    public ActivationType activationType;
    public int requiredCount;
    public float requiredMass;
   
    private float openCounter;
    public float openFor;
    

    protected bool m_eventfired;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OpenDoor();
    }
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (openCounter > 0)
        {
            openCounter -= Time.deltaTime;
        }
        if (openCounter <= 0)
            CloseDoor();
	}

    public void OpenTheDoor() {

        Debug.Log("open the door");

    }
    public void OpenDoor()
    {
        

        if (!m_eventfired && openCounter <= 0)
        {
            m_eventfired = true;
            openCounter = openFor;
            anim.SetBool("open", true);

            col.isTrigger = true;
            m_eventfired = false;

        }

    }
    public void CloseDoor()
    {
        if (openCounter <= 0)
        {
            openCounter = 0;
            anim.SetBool("open", false);

            col.isTrigger = false;
        }
    }
}
