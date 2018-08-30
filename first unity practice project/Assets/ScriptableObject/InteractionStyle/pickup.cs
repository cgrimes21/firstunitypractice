using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//pickup is called when you click an object that is interactable with an empty hand (nothing equipped)
public class pickup : IStyle {

    public override void Interact(Interactable what)
    {
        base.Interact(what);
        //attempt to grab it and put in into inventory
        //EquipmentManager.Pickup_Item(what.item);

        //Inventory.instance.Add(what);

    }
}
