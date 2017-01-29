using UnityEngine;
using UnityEngine.UI;

public class LookingHotspot : MonoBehaviour {

	Image img;
	Ray ray;
	RaycastHit hit;
	Vector3 center;
	FillAmountScript fill;
	GameObject lastRaycatHitObject;

	void Start () {
		center = new Vector3(Screen.width / 4,Screen.height / 2);
	}

	void Update () {
		ray = Camera.main.ScreenPointToRay (center);
		Debug.DrawRay (ray.origin, ray.direction, Color.red, 1.0f);
		if (Physics.Raycast (ray, out hit, 10000)) {
			Debug.Log (hit.transform.name);
			lastRaycatHitObject = hit.collider.gameObject;
			img = hit.collider.gameObject.GetComponent<Image> ();
			fill = hit.collider.gameObject.GetComponent<FillAmountScript> ();
			fill.canRay = true;
		} else if(lastRaycatHitObject != null) {
			fill = lastRaycatHitObject.GetComponent<FillAmountScript> ();
			fill.canRay = false;
		}
	}
}
