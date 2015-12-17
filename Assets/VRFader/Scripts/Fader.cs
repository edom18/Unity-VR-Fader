using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

	public GameObject FaderObject;

	[HideInInspector]
	public Fade Fade;

	private GameObject m_FaderObjectInstance;

	void Setup() {
		Debug.Log("Fader set up.");

		m_FaderObjectInstance = Instantiate(FaderObject, gameObject.transform.position, Quaternion.identity) as GameObject;
		m_FaderObjectInstance.transform.parent = gameObject.transform;
		m_FaderObjectInstance.SetActive(false);
		Fade = m_FaderObjectInstance.GetComponent<Fade>();
		Fade.OnFadeEnd += fadeEndHandler;
	}

	// Use this for initialization
	void Awake () {
		Debug.Log("Awake a fader.");

		Setup();
	}

	public void FadeIn() {
		Debug.Log("Start fade in.");

		m_FaderObjectInstance.SetActive(true);
		Fade.FadeIn();
	}

	public void FadeOut() {
		Debug.Log("Start fade out.");

		m_FaderObjectInstance.SetActive(true);
		Fade.FadeOut();
	}
	
	void fadeEndHandler() {
		Debug.Log("Perfrom fade end handler.");

		m_FaderObjectInstance.SetActive(false);
	}
}
