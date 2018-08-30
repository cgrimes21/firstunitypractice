using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class QuickSlotUI : MonoBehaviour {
    
	public Tilemap tileMap;
	public RectTransform right_click_item_group;
	public RectTransform rightclick_organiser;
	public InventorySlot rightclick_inv_slot_prefab;

	public AudioSource quickslotToggleSound;



	//Inventory
	public PlayerInventory inventory;
	public Transform item_slot_basic;
	InventorySlot[] slots_basic;

	private static bool UIExists;
	// Use this for initialization
	void Awake(){
		
		

		//if it comes active in our game, let's update it.
		if (inventory && (inventory.onItemChangedCallback != null))
			inventory.onItemChangedCallback.Invoke ();

	}
	void Start () {

		if(!UIExists)
		{
			UIExists = true;
			
			inventory.onItemChangedCallback += UpdateInventory;
			slots_basic = item_slot_basic.GetComponentsInChildren<InventorySlot> ();


			inventory.onItemChangedCallback.Invoke ();
		} else
		{
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Inventory")) {
			item_slot_basic.gameObject.SetActive (!item_slot_basic.gameObject.activeSelf);
			quickslotToggleSound.Play ();
		}

		if(GameManager.instance.mainPlayer.playerMoving==true)
			ClearRightClickDropDown ();
	}

	void UpdateInventory()
	{
		for (int i = 0; i < slots_basic.Length; i++) {
			if (i < inventory.items.Count) {
				slots_basic [i].AddItem (inventory.items [i]);
			} else {
				slots_basic [i].ClearSlot ();
			}
		}
	}

	public void check_rightclick_clear()
	{
		
		if (this.rightclick_organiser.transform.childCount <= 1)
			ClearRightClickDropDown ();
	}

	public void ClearRightClickDropDown(){
		
		foreach (Transform to_clear in this.rightclick_organiser.transform) {
			Destroy (to_clear.gameObject);
		}
		this.right_click_item_group.gameObject.SetActive (false);

	}

	public void UpdateRightClickDropDown()
	{
		
		
		ClearRightClickDropDown ();

		InventorySlot[] slots;
		List<item> what = new List<item> ();
		List<Transform> item_references = new List<Transform>();
		bool found = false;

		var mouseI = Input.mousePosition;
		mouseI.z = 10;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (mouseI);
		Vector3Int mpInt = new Vector3Int ((int)mousePos.x, (int)mousePos.y, (int)mousePos.z);
		Vector3 thetile = this.tileMap.GetCellCenterWorld (mpInt);


		foreach (Transform i in GameManager.instance.pickupable_items.transform) {

			if (utility.get_Distance (i.position) > i.GetComponent<Interactable> ().interact_radius) {
				//Debug.Log (i.GetComponent<Interactable> ().radius + " ALSO " + GameManager.instance.util.get_Distance (i.position));
				continue;
			}

			Vector3Int iINT = new Vector3Int ((int)i.transform.position.x, (int)i.transform.position.y, (int)i.transform.position.z);

			if (this.tileMap.GetCellCenterWorld (iINT) == thetile) {
                
				found = true;
				item what2 = i.GetComponent<Pickupable> ().item;
				if (what2 != null) {
					what.Add (what2);
					item_references.Add (i.transform);
				}
			}
		}

		if (found == true) {
			//reset the slots
			slots = new InventorySlot[what.Count];
			this.right_click_item_group.transform.position = new Vector3(Input.mousePosition.x+20,
				Input.mousePosition.y - 90, Input.mousePosition.z);
			this.right_click_item_group.gameObject.SetActive (true);

			for (int i = 0; i < what.Count; i++) {
				slots[i] = Instantiate (this.rightclick_inv_slot_prefab, this.rightclick_organiser);
				slots [i].AddItem (what[i]);
				slots [i].the_ref = item_references [i].GetComponent<Pickupable>();
			}
		}
	}
}
