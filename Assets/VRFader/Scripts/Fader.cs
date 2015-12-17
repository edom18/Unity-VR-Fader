using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

	public GameObject FaderObject;

	private bool isFaded = false;
	private Fade fade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isFaded) {
			return;
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			isFaded = true;

			GameObject faderIns = Instantiate(FaderObject, Camera.main.transform.position, Quaternion.identity) as GameObject;
			faderIns.transform.parent = gameObject.transform;
			fade = faderIns.GetComponent<Fade>();
			fade.OnFadeEnd += fadeEndHandler;
			fade.FadeOut();
		}
	}

	void fadeEndHandler() {
		fade.OnFadeEnd -= fadeEndHandler;
		fade.FadeIn();
	}
}
