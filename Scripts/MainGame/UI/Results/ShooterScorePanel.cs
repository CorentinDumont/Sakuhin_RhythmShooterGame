using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShooterScorePanel : MonoBehaviour {

	private Text shootingScore;
	private IEnumerator coroutine;

	void Awake () {
		if (GetComponentsInChildren<Text> ().Length == 2) {
			shootingScore = (GetComponentsInChildren<Text> ()) [1];
		}
	}

	public void SetScore(int score){
		if (coroutine != null) {
			StopCoroutine (coroutine);
		}
		coroutine = CoroutineSetScore (score);
		StartCoroutine (coroutine);
	}
	
	IEnumerator CoroutineSetScore(int score){
		if (shootingScore != null) {
			int buffer = 0;
			SetScoreText (buffer);
			while (buffer < score) {
				buffer = (int)Mathf.Min ((int)(buffer + score/30), score);
				SetScoreText (buffer);
				yield return null;
			}
		}
		coroutine = null;
		if (GameValuesContainer.container.menuWrapper.GetComponentInChildren<ResultsCanvas> () != null) {
			GameValuesContainer.container.menuWrapper.GetComponentInChildren<ResultsCanvas> ().OnScoreDisplayed ();
		}
	}

	public void SetScoreText(int points){
		int buff = points;
		int unit;
		string score = "";
		for (int i = 0; i < 9; i++) {
			unit = buff / (int)Mathf.Pow (10, 8 - i);
			buff = buff - unit * (int)Mathf.Pow (10, 8 - i);
			score += ""+unit;
			if (i==2 || i==5) {
				score += " ";
			}
		}
		shootingScore.text = score;
	}
}
