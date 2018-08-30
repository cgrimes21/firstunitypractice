using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject pickupable_items;

	public static bool isDebugOn = true;

	public List<GameObject> sounds = new List<GameObject> ();

	public playerController mainPlayer = null;
	
	public clickManager clickManager;
	public UIManager uiManager;


	void Awake()
	{
        instance = this;
		DontDestroyOnLoad (gameObject);
		if (mainPlayer == null) {
			GameObject temp = GameObject.Find ("player");
			mainPlayer = temp.GetComponent<playerController> ();

		}
		pickupable_items = GameObject.Find ("pickupable_objects");
		uiManager = GetComponent<UIManager> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void Debunk(string S)
	{
		if (isDebugOn)
			Debug.Log (S);
	}


}
