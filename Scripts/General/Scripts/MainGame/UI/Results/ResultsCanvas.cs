using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResultsCanvas : MonoBehaviour {

	public AudioClip calculationClip;
	public AudioClip endCalculationClip;

	private AudioSource audioSource;

	private ShooterScorePanel score;
	private RhythmScorePanel graph;
	private MultiplierScorePanel multiplier;

	private bool isDisplayedScore = false;
	private bool isDisplayedGraph = false;

	private bool isFinished = false;

	delegate void FooDelegate();

	void Awake(){
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = calculationClip;
		audioSource.loop = true;
		score = GetComponentInChildren<ShooterScorePanel>();
		graph = GetComponentInChildren<RhythmScorePanel>();
		multiplier = GetComponentInChildren<MultiplierScorePanel>();
	}

	void Update(){
		if (Input.GetKeyDown("return") && isFinished) {
			SceneManager.LoadSceneAsync ("StageSelection");
		}
	}

	public void StartDisplaying(){
		audioSource.Play ();
		DisplayScore ();
		DisplayGraph ();
	}

	void DisplayScore(){
		if (score != null) {
			score.SetScore ();
		}
	}

	public void OnScoreDisplayed(){
		isDisplayedScore = true;
		OnScoreAndGraphDisplayed ();
	}

	void DisplayGraph(){
		if (graph != null) {
			graph.SetScores ();
		}
	}

	public void OnGraphDisplayed(){
		isDisplayedGraph = true;
		OnScoreAndGraphDisplayed ();
	}

	void OnScoreAndGraphDisplayed(){
		if (isDisplayedGraph && isDisplayedScore) {
			audioSource.Stop ();
			audioSource.PlayOneShot (endCalculationClip);
			StartCoroutine(Delay(DisplayMultiplier,endCalculationClip.length+0.1f));
		}
	}

	void DisplayMultiplier(){
		audioSource.Play ();
		multiplier.DisplayMultiplier ();
	}

	public void OnMultiplierDisplayed(){
		audioSource.Stop ();
		audioSource.PlayOneShot (endCalculationClip);
		StartCoroutine(Delay(DisplayResult,endCalculationClip.length+0.1f));
	}

	void DisplayResult(){
		audioSource.Play ();
		multiplier.DisplayResult ();
	}

	public void OnResultDisplayed(){
		audioSource.Stop ();
		audioSource.PlayOneShot (endCalculationClip);
		StartCoroutine(Delay (SetFinished,0.5f));
	}

	void SetFinished(){
		isFinished = true;
	}

	IEnumerator Delay(FooDelegate function, float delay){
		float start = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < start + delay) {
			yield return null;
		}
		function ();
	}
}
