using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	item item;
	public Image icon;
	public Pickupable the_ref;
	int selected = 0;	//0 is off, 1 is left hand, 2 is right hand

	public void AddItem(item newitem)
	{
        if (newitem == null) return;

		item = newitem;
		icon.sprite = item.icon;
		icon.enabled = true;
		icon.color = Color.white;
	}

	public void ClearSlot(){
		item = null;
		icon.sprite = null;
		icon.enabled = false;

	}

	public void Select_LeftHand(){
	}

	public void Select_RightHand(){
	}

    /*
	public void AttemptPickups(){
        Debug.Log("attempting pickup in inventoryslot monob");
        if (item != null) {
			if (utility.get_Distance (the_ref.transform.position) <= the_ref.interact_radius) {
				if (.Add (item)) {
					ClearSlot ();
					Destroy (the_ref.gameObject);
					Destroy (this.gameObject);
					GameManager.instance.sounds [0].GetComponent<AudioSource> ().Play ();
					//QuickSlotUI.check_rightclick_clear ();
				}
			}
			


		}


}*/


}