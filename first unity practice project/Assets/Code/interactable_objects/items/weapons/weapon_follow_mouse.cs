using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_follow_mouse : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		//Rotation code
		var mousepos = Input.mousePosition;
		mousepos.z = 10;
		Vector3 difference = Camera.main.ScreenToWorldPoint (mousepos) - transform.position;
		difference.Normalize ();

		float rotationZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotationZ);

	}
}
