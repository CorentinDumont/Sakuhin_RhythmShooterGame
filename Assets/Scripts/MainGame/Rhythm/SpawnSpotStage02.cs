// Script attach to the object that will generate the bubbles for the rhythm game (see Bubble.cs, PlayerTile.cs)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnSpotStage02 : SpawnSpot {

	private bool oddBeatsUtility = false;

	override protected float[] BeatsTimes (){
		float[] times = new float[]{0.000f,0.625f,0.9375f,1.250f,1.5625f,1.71875f,1.875f,2.1875f,2.500f,3.125f,
			3.4375f,3.750f,4.0625f,4.21875f,4.375f,4.6875f,5.000f,5.625f,5.9375f,6.250f,
			6.5625f,6.71875f,6.875f,7.1875f,7.500f,8.125f,8.4375f,8.750f,9.0625f,9.21875f,
			9.375f,9.6875f};
		return times;
	}
	override protected string[] BeatsLabels (){
		string[] types = new string[]{"b1","b1","b2","b1","b2","b3","b1","b2","b1","b1",
			"b2","b1","b2","b3","b1","b2","b1","b1","b2","b1",
			"b2","b3","b1","b2","b1","b1","b2","b1","b2","b3",
			"b1","b2"};
		return types;
	}
	override protected void SpawnInRhythm(){
		float realTime = currentAudioTime + numberLoops * GetComponent<AudioSource> ().clip.length;
		float beatTimeBuff;
		if (beats["b1"].Count > 0 && beats["b1"].Peek () < realTime + reachTimesByDifficulty[difficulty-1]) {
			oddBeatsUtility = !oddBeatsUtility;
			beatTimeBuff = beats ["b1"].Dequeue ();
			if (difficulty > 1 || oddBeatsUtility) {
				Spawn (targets [0], beatTimeBuff - realTime,0);
			}
		}
		if (beats ["b2"].Count > 0 && beats ["b2"].Peek () < realTime + reachTimesByDifficulty[difficulty-1]) {
			beatTimeBuff = beats ["b2"].Dequeue ();
			if (difficulty > 2){
				Spawn (targets [1], beatTimeBuff - realTime,1);
			}
		}
		if (beats["b3"].Count > 0 && beats["b3"].Peek () < realTime + reachTimesByDifficulty[difficulty-1]) {
			beatTimeBuff = beats ["b3"].Dequeue ();
			if (difficulty > 3) {
				Spawn (targets [2], beatTimeBuff - realTime,2);
			}
		}
	}

}
