using UnityEngine;
using UnityEngine.EventSystems;

public class gun_shoot : MonoBehaviour {


	public float fireRate = 0;
	public float damage = 10;
	public LayerMask dontHit;
	public Transform bulletTrailPrefab;
	public float spawnRate = 10;
	public AudioSource au;
	public Transform muzzleFlashPrefab;
	public Transform hitPrefab;

	private float timeToSpawnEffect = 0;
	private float timeToFire = 0;
	private Transform firePoint;

	// Use this for initialization
	void Awake () {
		firePoint = transform.Find ("firepoint");
		if (firePoint == null) {
			Debug.LogError ("Didn't find firepoint for weapon " + transform.name);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (EventSystem.current.IsPointerOverGameObject ())
			return;
        
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shoot ();
			}
		} else {
			//its not single burst but automatic
			if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				Shoot ();
			}
		}
	}

	void Shoot(){
		var mousepos = Input.mousePosition;
		mousepos.z = 10;
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (mousepos).x,
			                        Camera.main.ScreenToWorldPoint (mousepos).y);

		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition, 100, ~dontHit);


		Debug.DrawLine (firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
		}

		if (Time.time >= timeToSpawnEffect) {
			Vector3 hitPos;
			Vector3 hitNormal;
			if (hit.collider == null) {
				hitPos = (mousePosition + firePointPosition) * 30;
				hitNormal = new Vector3 (9999, 9999, 9999);
			} else {
				hitPos = hit.point;
				hitNormal = hit.normal;
			}
		

			Effect (hitPos, hitNormal);
			timeToSpawnEffect = Time.time + 1 / spawnRate;
		}
	}
	void Effect(Vector3 hitPos, Vector3 hitNorm){
		au.Play ();
		Transform trail = Instantiate (bulletTrailPrefab, firePoint.position, firePoint.rotation)as Transform ;
		LineRenderer lr = trail.GetComponent <LineRenderer> ();
		if (lr != null) {
			lr.SetPosition (0, firePoint.position);
			lr.SetPosition (1, hitPos);
		}

		Destroy (trail.gameObject, 0.06f);

		if (hitNorm != new Vector3 (9999, 9999, 9999)) {
			Instantiate(hitPrefab, new Vector3(hitPos.x,hitPos.y,-0.35f), Quaternion.FromToRotation(Vector3.right, hitNorm));
		}

		Transform clone = Instantiate (muzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
		clone.parent = firePoint;
		float size = Random.Range (0.6f, 0.9f);
		clone.localScale = new Vector3 (size, size, size);
		Camera_Shake.Shake ();
		Destroy (clone.gameObject, 0.02f);
	}
}
