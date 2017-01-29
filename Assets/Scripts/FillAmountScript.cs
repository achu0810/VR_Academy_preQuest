using UnityEngine;
using UnityEngine.UI;

public class FillAmountScript : MonoBehaviour {

	public bool canRay = false;
	Image img;
	bool initialize = true;
	Vector3 defaultSize;

	void Start () {
		img = GetComponent<Image> ();
		defaultSize = this.transform.localScale;
	}

	void Update () {
		if (!canRay) {
			img.fillAmount = 1.0f;
			initialize = true;
			this.transform.localScale = defaultSize;
		} else {
			if (initialize) {
				img.fillAmount = 0.0f;
				this.transform.localScale = new Vector3 (defaultSize.x * 1.5f, defaultSize.y * 1.5f);
				initialize = false;
			}
			img.fillAmount += 1.0f * Time.deltaTime;
		}
	}
}
