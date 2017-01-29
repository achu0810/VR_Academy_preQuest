using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

	public float speed;
	Quaternion _attitude;

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
		#elif UNITY_IOS || UNITY_ANDROID
		Input.gyro.enabled = true;
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		
		#if UNITY_EDITOR
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.Rotate (Vector3.up * -Time.deltaTime * speed, Space.World);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.Rotate (Vector3.up * Time.deltaTime * speed, Space.World);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			this.transform.Rotate (Vector3.left * Time.deltaTime * speed);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			this.transform.Rotate (Vector3.left * Time.deltaTime * -speed);
		}

		#elif UNITY_IOS || UNITY_ANDROID
		_attitude = Input.gyro.attitude;
		_attitude.x *= -1; _attitude.y *= -1;
		this.transform.rotation = Quaternion.AngleAxis(90f, Vector3.right) * _attitude;
		#endif
	}
}
