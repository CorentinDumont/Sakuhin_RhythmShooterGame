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

	void Update(){
		if (Input.GetKeyDown("return")) {
			if (coroutine != null) {
				StopCoroutine (coroutine);
				coroutine = null;
				SetScoreText (GameValuesContainer.container.shootingScore);
				GameValuesContainer.container.menuWrapper.GetComponentInChildren<ResultsCanvas> ().OnScoreDisplayed ();
			}
		}
	}

	public void SetScore(){
		if (coroutine != null) {
			StopCoroutine (coroutine);
		}
		coroutine = CoroutineSetScore ();
		StartCoroutine (coroutine);
	}
	
	IEnumerator CoroutineSetScore(){
		int score = GameValuesContainer.container.shootingScore;
		if (shootingScore != null) {
			int buffer = 0;
			SetScoreText (buffer);
			if(score>0){
				while (buffer < score) {
					buffer = (int)Mathf.Min ((int)(buffer + score/100f), score);
					SetScoreText (buffer);
					yield return null;
				}
			}
		}
		coroutine = null;
		GameValuesContainer.container.menuWrapper.GetComponentInChildren<ResultsCanvas> ().OnScoreDisplayed ();
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
