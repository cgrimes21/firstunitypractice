using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerInventory : ScriptableObject {

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 5;

    public List<item> items = new List<item>();

    public bool Add(item item)
    {
        if (items.Count >= space)
            return false;
        items.Add(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        return true;
    }

    public void Remove(item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void removenulls(){
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
                items.Remove(items[i]);
        }
    }
	
}
