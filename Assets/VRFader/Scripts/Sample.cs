using UnityEngine;
using System.Collections;

public class Sample : MonoBehaviour {

	private bool m_Toggle = false;

	private Fader m_Fader;

	// Use this for initialization
	void Start () {
		m_Fader = GetComponent<Fader>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			if (m_Fader.IsFading) {
				return;
			}

			m_Toggle = !m_Toggle;
			if (m_Toggle) {
				m_Fader.FadeOut();
			}
			else {
				m_Fader.FadeIn();
			}
		}
	}
}
