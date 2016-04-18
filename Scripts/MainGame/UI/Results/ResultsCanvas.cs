using UnityEngine;
using System.Collections;

public class ResultsCanvas : MonoBehaviour {

	private ShooterScorePanel score;
	private RhythmScorePanel graph;
	private MultiplierScorePanel multiplier;

	private bool isDisplayedScore = false;
	private bool isDisplayedGraph = false;

	void Awake(){
		score = GetComponentInChildren<ShooterScorePanel>();
		graph = GetComponentInChildren<RhythmScorePanel>();
		multiplier = GetComponentInChildren<MultiplierScorePanel>();
	}

	public void StartDisplaying(){
		DisplayScore ();
		DisplayGraph ();
	}

	public void DisplayScore(){
		if (score != null) {
			score.SetScore (GameValuesContainer.container.shootingScore);
		}
	}

	public void OnScoreDisplayed(){
		isDisplayedScore = true;
		DisplayMultiplier ();
	}

	public void DisplayGraph(){
		if (graph != null) {
			float[] rhythmScores = new float[6];
			for (int i = 0; i < 6; i++) {
				rhythmScores [i] = GameValuesContainer.container.rhythmScores [i];
			}
			graph.SetScores (rhythmScores);
		}
	}

	public void OnGraphDisplayed(){
		isDisplayedGraph = true;
		DisplayMultiplier ();
	}

	public void DisplayMultiplier(){
		if (isDisplayedScore && isDisplayedGraph) {
			multiplier.DisplayResult ();
		}
	}
}
