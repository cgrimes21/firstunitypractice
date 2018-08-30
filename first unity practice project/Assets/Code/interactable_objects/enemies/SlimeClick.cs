using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeClick : Interactable {

	public override void clicked()
	{
		Debug.Log ("run slime behavior");
		base.clicked ();
	}

}
