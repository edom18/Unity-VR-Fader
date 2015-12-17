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
	#endregion

	private YieldInstruction m_Instruction = new WaitForEndOfFrame();

	public void FadeIn() {
		StartCoroutine(FadeStart(true));
	}

	public void FadeOut() {
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

		Debug.Log("Fade end!!");
		OnFadeEnd();
	}
}
