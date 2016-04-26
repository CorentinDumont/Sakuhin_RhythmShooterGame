using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MultiplierScorePanel : MonoBehaviour {

	private Text multiplier;
	private Text result;

	private int multiplierValue = 0;
	private int resultValue = 0;


	private IEnumerator coroutineMultiplier;
	private IEnumerator coroutineResult;

	void Awake () {
		if (GetComponentsInChildren<Text> ().Length == 2) {
			multiplier = (GetComponentsInChildren<Text> ()) [0];
			result = (GetComponentsInChildren<Text> ()) [1];
		}
	}

	void Update(){
		if (Input.GetKeyDown("return")) {
			if (coroutineMultiplier != null) {
				StopCoroutine (coroutineMultiplier);
				coroutineMultiplier = null;
				multiplier.text = "x " + multiplierValue;
				GameValuesContainer.container.menuWrapper.GetComponentInChildren<ResultsCanvas> ().OnMultiplierDisplayed ();
			}
			else if (coroutineResult != null) {
				StopCoroutine (coroutineResult);
				coroutineResult = null;
				result.text = "= " + resultValue;
				GameValuesContainer.container.menuWrapper.GetComponentInChildren<ResultsCanvas> ().OnResultDisplayed ();
			}
		}
	}

	public void DisplayMultiplier(){
		multiplier.text = "x 0";
		if (coroutineMultiplier != null) {
			StopCoroutine (coroutineMultiplier);
		}
		coroutineMultiplier = CoroutineDisplayMultiplier ();
		StartCoroutine (coroutineMultiplier);
	}

	public void DisplayResult(){
		result.text = "= 0";
		if (coroutineResult != null) {
			StopCoroutine (coroutineResult);
		}
		coroutineResult = CoroutineDisplayResult ();
		StartCoroutine (coroutineResult);
	}

	IEnumerator CoroutineDisplayMultiplier(){
		int[] rhythmScores = GameValuesContainer.container.rhythmScores;
		int[] coef = new int[6]{ 0, 1, 2, 3, 4, 5 };
		multiplierValue = 0;
		for (int i = 0; i < 6; i++) {
			multiplierValue += rhythmScores [i] * coef [i];
		}
		if (multiplierValue > 0) {
			float buffer = 0;
			while (buffer < multiplierValue) {
				buffer = Mathf.Min (buffer + (float)multiplierValue / 50f, multiplierValue);
				if (multiplier != null) {
					multiplier.text = "x " + (int)buffer;
				}
				yield return null;
			}
		}
		coroutineMultiplier = null;
		GameValuesContainer.container.menuWrapper.GetComponentInChildren<ResultsCanvas> ().OnMultiplierDisplayed ();
	}

	IEnumerator CoroutineDisplayResult(){
		resultValue = multiplierValue * GameValuesContainer.container.shootingScore;
		if (resultValue > 0) {
			float buffer = 0;
			while (buffer < resultValue) {
				buffer = Mathf.Min (buffer + (float)resultValue / 70f, resultValue);
				if (result != null) {
					result.text = "= " + (int)buffer;
				}
				yield return null;
			}
		}
		coroutineResult = null;
		GameValuesContainer.container.menuWrapper.GetComponentInChildren<ResultsCanvas> ().OnResultDisplayed ();
	}
}
