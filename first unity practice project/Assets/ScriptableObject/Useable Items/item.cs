using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Interactable/useable_item/item")]
public class item : ScriptableObject
{
    
    public string aName = "Useable Item";
    public Sprite icon = null;


    public virtual void Initialize(GameObject what){
    }

    public virtual void Pickup(){

        GameManager.instance.sounds[0].GetComponent<AudioSource>().Play();

    }
    public virtual void Drop(){}


    public virtual void onclicked()
    {
        Debug.Log("yeah click Object blueprint...");
    }

    //Called when this item is clicked with an open hand, NOT in gui
    public void InteractWithHand(){
        
    }

    //Called when this item is clicked with 'what' in players hand
    public void InteractWithOther(item what){
        
    }


}
