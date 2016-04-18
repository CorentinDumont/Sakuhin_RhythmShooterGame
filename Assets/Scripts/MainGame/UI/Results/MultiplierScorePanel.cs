using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MultiplierScorePanel : MonoBehaviour {

	private Text multiplier;
	private Text result;

	private int multiplierValue = 0;


	private IEnumerator coroutineMultiplier;
	private IEnumerator coroutineResult;

	void Awake () {
		if (GetComponentsInChildren<Text> ().Length == 2) {
			multiplier = (GetComponentsInChildren<Text> ()) [0];
			result = (GetComponentsInChildren<Text> ()) [1];
		}
	}

	public void DisplayResult(){
		if (coroutineMultiplier != null) {
			StopCoroutine (coroutineMultiplier);
			if (result != null) {
				result.text = "= 0";
			}
		}
		if (coroutineResult != null) {
			StopCoroutine (coroutineMultiplier);
			if (result != null) {
				result.text = "= 0";
			}
		}
		coroutineMultiplier = CoroutineDisplayMultiplier ();
		StartCoroutine (coroutineMultiplier);
	}

	IEnumerator CoroutineDisplayMultiplier(){
		int[] rhythmScores = GameValuesContainer.container.rhythmScores;
		int[] coef = new int[6]{ 0, 1, 2, 3, 4, 5 };
		multiplierValue = 0;
		for (int i = 0; i < 6; i++) {
			multiplierValue += rhythmScores [i] * coef [i];
		}
		int buffer = 0;
		while (buffer < multiplierValue) {
			buffer = (int)Mathf.Min (buffer + multiplierValue / 30, multiplierValue);
			if (multiplier != null) {
				multiplier.text = "x " + buffer;
			}
			yield return null;
		}
		coroutineResult = CoroutineDisplayResult ();
		StartCoroutine (coroutineResult);
	}

	IEnumerator CoroutineDisplayResult(){
		int resultValue = multiplierValue * GameValuesContainer.container.shootingScore;
		int buffer = 0;
		while (buffer < resultValue) {
			buffer = (int)Mathf.Min (buffer + resultValue / 30, resultValue);
			if (result != null) {
				result.text = "= " + buffer;
			}
			yield return null;
		}
	}
}
