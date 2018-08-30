using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

//Put this on any object that is able to be picked up
public class Pickupable : Interactable {
    
    public void Awake()
    {

    }
    protected override void Start(){
        transform.Rotate (new Vector3(0f, 0f, Random.Range (0, 360)));
    }

    //pickup through clicks
    public override void clicked()
    {
        base.clicked ();

        EquipmentManager.Pickup_Item(this);

        //invoke a pickupitem event that equipment manager listens for
        //Pickup_Item ();
    }


    //obsolete
    /*
    public void Pickup_Item()
    {
        if (utility.get_Distance (transform.position) <= interact_radius) {
            //if we do not have an empty hand, don't pick up right now.
           // if (!EquipmentManager.HasEmptyHand())
             //   return;
                
            if (Inventory.instance.Add (item)) {

                item.Pickup();
                
                Destroy (gameObject);
            }
        }
    }
    */

}
