using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

	public float interact_radius = 1.5f;
    public item item;
    public IStyle interactStyle;


	public virtual void clicked()
	{
        
	}

	protected virtual void OnBump()
	{
	}

	protected virtual void interact()
	{
	}

	public void OnClicked()
	{
		clicked ();
	}


	// Use this for initialization
	protected virtual void Start () {


	}

    public void Initialize()
    {
        
        Start();
    }

    // Update is called once per frame
    protected virtual void Update () {
		
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, interact_radius);
	}
}
