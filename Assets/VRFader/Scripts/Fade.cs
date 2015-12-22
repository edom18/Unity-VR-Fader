using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	#region Public variables
	public GameObject TopSphere;
	public GameObject BottomSphere;
	public float Duration = 10f;
	public float TargetOpaque = 50f;

	public delegate void fadeEnd();
	public event fadeEnd OnFadeEnd = delegate {};
	public bool IsFading = false;
	#endregion

	private YieldInstruction m_Instruction = new WaitForEndOfFrame();

	void Start() {
		OnFadeEnd += FadeEndHandler;
	}

	void FadeEndHandler() {
		IsFading = false;
	}

	public void FadeIn() {
		if (IsFading) {
			return;
		}
		Debug.Log("Start fade in.");
		IsFading = true;

		StartCoroutine(FadeStart(true));
	}

	public void FadeOut() {
		if (IsFading) {
			return;
		}
		Debug.Log("Start fade out.");
		IsFading = true;

		StartCoroutine(FadeStart(false));
	}

	IEnumerator FadeStart(bool isFadeIn) {
		float elapsedTime = 0f;
		float t = 0f;

		Material topMaterial    = TopSphere.GetComponent<MeshRenderer>().material;
		Material bottomMaterial = BottomSphere.GetComponent<MeshRenderer>().material;

		while (t <= 1f) {
			yield return m_Instruction;

			elapsedTime += Time.deltaTime;
			t = elapsedTime / Duration;
			t = t - 1f;
			t = Mathf.Pow(t, 5) + 1f;

			float value;
			if (isFadeIn) {
				value = (1f - t) * TargetOpaque;
			}
			else {
				value = t * TargetOpaque;
			}
			topMaterial.SetFloat("_Width", value);
			bottomMaterial.SetFloat("_Width", value);
		}

		OnFadeEnd();

		Debug.Log("Fade end!!");
	}
}
