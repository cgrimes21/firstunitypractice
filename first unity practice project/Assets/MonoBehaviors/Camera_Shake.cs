using UnityEngine;

public class Camera_Shake : MonoBehaviour{

	public static Camera_Shake instance;


	Vector3 lastPos;
	public float sinceShakeTime = 0.0f;
	public  float shakeIntensity = 0.2f;

	void OnEnable(){
		instance = this;

	}
	void Start(){
		instance = this;
	}

    /*Doesn't work with lightweight pipeline
    void OnPreRender(){
		if (sinceShakeTime > 0.0f) {
			lastPos = Random.insideUnitCircle * shakeIntensity;
			transform.localPosition = transform.localPosition + lastPos;
		}

	}

	void OnPostRender(){
		if (sinceShakeTime > 0.0f) {
			transform.localPosition = transform.localPosition - lastPos;
			sinceShakeTime -= Time.deltaTime;
		
		}
	}

    */
	public static void Shake(float amt = 0.3f, float length = 0.5f){
		if (instance==null)
			return;


		instance.shakeIntensity = amt;
        //instance.sinceShakeTime = 0.5f;

		instance.InvokeRepeating ("BeginShake", 0, 0.05f);
		instance.Invoke ("StopShake", length);
	}




	void BeginShake(){
		if (instance.shakeIntensity > 0.0f) {
            
            if (this.transform.localPosition == Vector3.zero)
            {
                lastPos = Random.insideUnitCircle * instance.shakeIntensity;
            }
            else
            {
                lastPos = Vector3.zero;
            }
            transform.localPosition = lastPos;


            /*
			Vector3 camPos = this.transform.position;
            float shakeAmtX = Random.value * shakeIntensity * 2 - shakeIntensity;
			float shakeAmtY = Random.value * shakeIntensity * 2 - shakeIntensity;
			camPos.x += shakeAmtX;
			camPos.y += shakeAmtY;

			this.transform.position = camPos;
            */
			
		}

	}

	void StopShake(){
		CancelInvoke ("BeginShake");
		this.transform.localPosition = Vector3.zero;
	}
}
