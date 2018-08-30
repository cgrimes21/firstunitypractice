using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script manages and controls all equipment related functionality:

public class EquipmentManager : MonoBehaviour {
    
    public delegate void pickup_item_del(Pickupable what);
    public static pickup_item_del Pickup_Item;

    public PlayerInventory playerInventory;

    [SerializeField]
    private item lefthand;
    [SerializeField]
    private item righthand;


    public void Start()
    {
        Pickup_Item += Pickup_Item_Del;
        playerInventory.onItemChangedCallback += playerInventory.removenulls;
    }
    public void OnDisable()
    {
        Pickup_Item -= Pickup_Item_Del;
        playerInventory.onItemChangedCallback -= playerInventory.removenulls;
    }



    void Pickup_Item_Del(Pickupable what){
        if (utility.get_Distance(what.transform.position) <= what.interact_radius)
        {
            //if we do not have an empty hand, don't pick up right now.
            if (!HasEmptyHand())
                return;

            if (playerInventory.Add(what.item))
            {
                what.item.Pickup();

                Destroy(what.gameObject);
            }
        }
    }
    //custom
    bool HasEmptyHand(){
        bool yes = true;

        if (lefthand.aName != "Useable Item")
            yes = false;
        if (righthand.aName != "Useable Item")
            yes = false;
        return yes;
    }

    public static void dothis() { }

    public static void OnChanged(){}


}
