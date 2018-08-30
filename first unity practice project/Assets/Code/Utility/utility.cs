using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class utility {

	/*
	public bool isNear(Vector2 who)
	{
		Collider cd = Physics.OverlapSphere (GameManager.instance.mainPlayer.transform.position, 1.5f);
		GameManager.Debunk ("isNear is " + );
	}
	*/
	public static float get_Distance(Vector2 who)
	{
		float what = Vector2.Distance (GameManager.instance.mainPlayer.transform.position, who);
		return what;

	}


	void Awake()
	{
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
