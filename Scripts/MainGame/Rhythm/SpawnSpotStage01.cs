// Script attach to the object that will generate the bubbles for the rhythm game (see Bubble.cs, PlayerTile.cs)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnSpotStage01 : SpawnSpot {

	private bool oddBeatsUtility = false;

	override protected float[] BeatsTimes (){
		float[] times = new float[]{0.0f,0.104f,0.207f,0.311f,0.414f,0.518f,0.622f,0.622f,0.725f,0.829f,
			0.932f,1.036f,1.139f,1.243f,1.243f,1.657f,1.761f,1.865f,1.968f,2.072f,
			2.175f,2.279f,2.383f,2.486f,2.59f,2.693f,2.797f,2.9f,3.004f,3.108f,
			3.211f,3.315f,3.418f,3.522f,3.626f,3.729f,3.833f,3.936f,3.936f,4.04f,
			4.144f,4.247f,4.351f,4.454f,4.558f,4.558f,4.972f,5.076f,5.179f,5.283f,
			5.387f,5.49f,5.594f,5.697f,5.801f,5.905f,6.008f,6.112f,6.215f,6.319f,
			6.423f,6.526f,6.63f,6.733f,6.837f,6.94f,7.044f,7.148f,7.251f,7.251f,
			7.355f,7.458f,7.458f,7.562f,7.666f,7.769f,7.873f,7.873f,8.08f,8.287f,
			8.391f,8.494f,8.598f,8.701f,8.805f,8.909f,9.012f,9.116f,9.219f,9.323f,
			9.427f,9.53f,9.634f,9.737f,9.841f,9.945f,10.048f,10.152f,10.255f,10.359f,
			10.462f,10.566f,10.566f,10.67f,10.773f,10.773f,10.877f,10.98f,11.084f,11.188f,
			11.188f,11.395f,11.602f,11.706f,11.809f,11.913f,12.016f,12.12f,12.223f,12.327f,
			12.431f,12.534f,12.638f,12.741f,12.845f,12.949f,13.052f,13.156f};
		return times;
	}
	override protected string[] BeatsLabels (){
		string[] types = new string[]{"b0","b1","b2","b3","b0","b1","b2","p1","b3","b0",
			"b1","b2","b3","b0","p1","b0","b1","b2","b3","b0",
			"b1","b2","b3","b0","b1","b2","b3","b0","b1","b2",
			"b3","b0","b1","b2","b3","b0","b1","b2","p1","b3",
			"b0","b1","b2","b3","b0","p1","b0","b1","b2","b3",
			"b0","b1","b2","b3","b0","b1","b2","b3","b0","b1",
			"b2","b3","b0","b1","b2","b3","b0","b1","b2","p1",
			"b3","p1","b0","b1","b2","b3","b0","p1","p1","b0",
			"b1","b2","b3","b0","b1","b2","b3","b0","b1","b2",
			"b3","b0","b1","b2","b3","b0","b1","b2","b3","b0",
			"b1","b2","p1","b3","p1","b0","b1","b2","b3","b0",
			"p1","p1","b0","b1","b2","b3","b0","b1","b2","b3",
			"b0","b1","b2","b3","b0","b1","b2","b3"};
		return types;
	}
	override protected void SpawnInRhythm(){
		float realTime = currentAudioTime + numberLoops * GetComponent<AudioSource> ().clip.length;
		float beatTimeBuff;
		if (beats["p1"].Count > 0 && beats["p1"].Peek () < realTime + reachTimesByDifficulty[difficulty-1]) {
			beatTimeBuff = beats ["p1"].Dequeue ();
			Spawn (targets[0],beatTimeBuff - realTime,2);
		}
		if (beats["b0"].Count > 0 && beats["b0"].Peek () < realTime + reachTimesByDifficulty[difficulty-1]) {
			oddBeatsUtility = !oddBeatsUtility;
			beatTimeBuff = beats ["b0"].Dequeue ();
			if (difficulty > 2 || (difficulty > 1 && oddBeatsUtility)) {
				Spawn (targets [1], beatTimeBuff - realTime,0);
			}
		}
		if (beats["b1"].Count > 0 && beats["b1"].Peek () < realTime + reachTimesByDifficulty[difficulty-1]) {
			beatTimeBuff = beats ["b1"].Dequeue ();
			//Spawn (targets[1],beatTimeBuff - realTime);
		}
		if (beats ["b2"].Count > 0 && beats ["b2"].Peek () < realTime + reachTimesByDifficulty[difficulty-1]) {
			beatTimeBuff = beats ["b2"].Dequeue ();
			if (difficulty > 3){
				Spawn (targets [2], beatTimeBuff - realTime,1);
			}
		}
		if (beats["b3"].Count > 0 && beats["b3"].Peek () < realTime + reachTimesByDifficulty[difficulty-1]) {
			beatTimeBuff = beats ["b3"].Dequeue ();
			//Spawn (targets[2],beatTimeBuff - realTime);
		}
	}

}
