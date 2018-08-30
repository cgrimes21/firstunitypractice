using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class clickManager : MonoBehaviour {
    //[Serializable]
    //public class Whatthefuck : UnityEvent<Interactable> {}
    //public Whatthefuck WTF;


    public UnityEvent updateRightClickDropdown;
    public UnityEvent clearRightClickDropdown;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (1)) {
            updateRightClickDropdown.Invoke();

			//QuickSlotUI.UpdateRightClickDropDown ();
		}

		if (Input.GetMouseButtonDown (0)) {

			//if we're over a UI, don't do anything
			if (EventSystem.current.IsPointerOverGameObject ())
				return;

            //since we're not in our ui, lets clear any right clicks
            clearRightClickDropdown.Invoke();
            //QuickSlotUI.ClearRightClickDropDown();

			var mouseI = Input.mousePosition;
			mouseI.z = 10;
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (mouseI);
			Vector2 mousePos2D = new Vector2 (mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast (mousePos2D, Vector2.zero);

            //anything with a collider able to be clicked will be listening for this event
            if (hit.collider != null) {
                
                Interactable what = hit.collider.GetComponent<Interactable> ();
                if(what != null)
                  //  WTF.Invoke(what);
				    OnInteract (what);

			}

		}
	}


	public void OnInteract(Interactable who)
	{
		if (who != null)
			who.OnClicked ();
	}


}
