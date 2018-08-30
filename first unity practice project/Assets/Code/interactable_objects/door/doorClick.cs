using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class doorClick : Interactable {

	public override void clicked()
	{
		
		if (utility.get_Distance (transform.position) <= 1.5)
			GetComponent<doorHandler> ().OpenDoor ();
		
		base.clicked ();
	}


}
