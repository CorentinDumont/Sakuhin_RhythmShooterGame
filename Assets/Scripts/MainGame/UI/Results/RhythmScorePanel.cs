using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RhythmScorePanel : MonoBehaviour {

	private RhythmGraph graph;
	private RhythmLabel label;
	private IEnumerator coroutine = null;

	// Use this for initialization
	void Awake () {
		graph = GetComponentInChildren<RhythmGraph> ();
		label = GetComponentInChildren<RhythmLabel> ();
		UpdateLayout ();
	}

	void OnRectTransformDimensionsChange()
	{
		UpdateLayout ();
	}

	public void SetScores(float[] scores){
		if (coroutine != null) {
			StopCoroutine (coroutine);
		}
		coroutine = CoroutineSetScores (scores);
		StartCoroutine (coroutine);
	}

	IEnumerator CoroutineSetScores(float[] scores){
		float max = MaxScore (scores);
		if (scores.Length == 6 && max>0) {
			float f = 0;
			while (f < max) {
				f = Mathf.Min(f+max/30,max);
				for (int j = 0; j < 6; j++) {
					graph.SetScore(j,Mathf.Min (scores[j], f));
				}
				graph.DisplayResults (MaxScore(scores));
				yield return null;
			}
		}
		coroutine = null;
		if (GameValuesContainer.container.menuWrapper.GetComponentInChildren<ResultsCanvas> () != null) {
			GameValuesContainer.container.menuWrapper.GetComponentInChildren<ResultsCanvas> ().OnGraphDisplayed ();
		}
	}

	float MaxScore(float[] array){
		float max = 0;
		foreach(float num in array){
			max = Mathf.Max (max, num);
		}
		return max;
	}

	void UpdateLayout(){
		Vector2 sizePanel = GetComponent<RectTransform> ().sizeDelta;
		Vector2 pivot = GetComponent<RectTransform> ().pivot - new Vector2 (0.5f, 0.5f);
		if (graph != null && label != null) {
			graph.gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (sizePanel.x, sizePanel.y * 0.8f);
			graph.gameObject.GetComponent<RectTransform> ().localPosition = new Vector3 (-sizePanel.x * pivot.x, sizePanel.y * 0.1f - sizePanel.y * pivot.y, 0);
			label.gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (sizePanel.x, sizePanel.y * 0.2f);
			label.gameObject.GetComponent<RectTransform> ().localPosition = new Vector3 (-sizePanel.x * pivot.x, -sizePanel.y * 0.4f - sizePanel.y * pivot.y, 0);
		}
	}
}
