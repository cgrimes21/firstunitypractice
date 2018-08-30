using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameraController : MonoBehaviour
{

    public GameObject followTarget;
    private Vector3 targetPosition;
    private static bool cameraExists;
	[Range(0.0f,2.0f)]
    public float moveSpeed;

	//used for clamping in future
	public float minX = 0;
	public float maxX = 0;
	public float minY = 0;
	public float maxY = 0;

	private Vector3 camVelocity = Vector3.zero;

    // Use this for initialization
    void Start()
    {

        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

		minX = Mathf.NegativeInfinity;
		maxX = Mathf.Infinity;
		minY = Mathf.NegativeInfinity;
		maxY = Mathf.Infinity;


    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(followTarget.transform.position.x,
            followTarget.transform.position.y, transform.position.z);
		//Clamp our camera
		Vector3 newpos = Vector3.SmoothDamp (transform.position, targetPosition, ref camVelocity, (1/moveSpeed));
		//if clamp:
		//newpos = clamper(newpos); 
		transform.position = newpos;

		//transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

	Vector3 clamper(Vector3 inn)
	{
		return new Vector3 (Mathf.Clamp (inn.x, minX, maxX), Mathf.Clamp (inn.y, minY, maxY), inn.z);

	}



}
