// Script attach to the object that will generate the bubbles for the rhythm game (see Bubble.cs, PlayerTile.cs)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

abstract public class SpawnSpot : MonoBehaviour {

	public GameObject[] bubbles; // prefabs of the Bubbles
	public GameObject[] targets; // the target to reach (may be changed to an array of several targets)
	public float[] reachTimesByDifficulty = new float[4]{1f,1f,1f,1f}; // Times for bubbles to reach their target

	protected float stageDuration; // length of the stage
	protected bool isInitialized = false;
	protected int difficulty = 1; // difficulty (will varies in function of used items
	protected float currentAudioTime = 0;
	protected int numberLoops = 0;
	protected Dictionary<string, Queue<float> > beats; // Contains the beats pattern of the stage

	abstract protected float[] BeatsTimes ();
	abstract protected string[] BeatsLabels ();
	abstract protected void SpawnInRhythm ();

	void Start(){
		stageDuration = GameValuesContainer.container.stageDuration;
		fillBeats ();
	}

	void fillBeats(){ // Defines the times where the beats of the rhythm games are
		beats = new Dictionary<string, Queue<float> >();
		float[] times = BeatsTimes ();
		string[] types = BeatsLabels ();
		float time = 0;
		int loop = -1;
		int i = 0;
		while (time < stageDuration) {
			if (i == 0) {
				loop += 1;
			}
			time = times [i] + loop * GameValuesContainer.container.audioHandler.stageMusic.length;
			if (!beats.ContainsKey (types [i])) {
				beats [types [i]] = new Queue<float> ();
			}
			beats [types [i]].Enqueue (time);
			i = (int)Mathf.Repeat (i + 1, Mathf.Min (times.Length, types.Length));
		}

	}

	public float GetTime(){
		UpdateCurrentAudioTime ();
		return currentAudioTime + numberLoops * GameValuesContainer.container.audioHandler.stageMusic.length;
	}

	void setDifficulty(int difficulty){
		this.difficulty = difficulty;
	}

	public void IncreaseDifficulty(){
		setDifficulty (Mathf.Min(4,difficulty + 1));
	}

	public void DecreaseDifficulty(){
		setDifficulty (Mathf.Max(1,difficulty - 1));
	}

	protected void Spawn(GameObject target, float reachTime, int bubbleIndex=0){ // Spawn a bubble
		if (reachTime > 0.90*reachTimesByDifficulty [difficulty - 1]) {
			GameObject go = (GameObject)Instantiate (bubbles[bubbleIndex], this.transform.position, Quaternion.identity);
			go.transform.SetParent (GameValuesContainer.container.bubblesContainer.transform);
			go.GetComponent<Bubble> ().Initialize (target, reachTime);
		}
	}

	void UpdateCurrentAudioTime(){
		if (GameValuesContainer.container.audioHandler.isPlayingRhythmGame()) {
			if (GameValuesContainer.container.audioHandler.GetComponent<AudioSource> ().time < currentAudioTime) {
				numberLoops++;
			}
			currentAudioTime = GameValuesContainer.container.audioHandler.GetComponent<AudioSource> ().time;
		}
	}

	// Update is called once per frame
	void Update () {
		if (GameValuesContainer.container.audioHandler.isPlayingRhythmGame()) {
			UpdateCurrentAudioTime ();
			////////////////////////////////////////////////
			////// Spawning in function of difficulty //////
			////////////////////////////////////////////////
			SpawnInRhythm();
		}
	}
}