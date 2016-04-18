// script used to spawn enemies and asteroids
// attached to an object not visible on the screen, at the top of the playing field

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemies; // ennemies that can be generated (ships, asteroids...)
	public GameObject boss;
	private Dictionary< int,Queue< Pair<float,float> > > spawns;

	protected int difficulty = 1; // difficulty (will varies in function of used items

	void Awake(){
		fillSpawns ();
	}

	void fillSpawns(){ // Defines the times where the beats of the rhythm games are
		spawns = new Dictionary<int,Queue< Pair<float,float> > >();
		float[] times = SpawnsTimes ();
		int[] types = SpawnsTypes ();
		float[] positions = SpawnsPositions ();
		for (int i=0;i<Mathf.Min(times.Length,types.Length);i++) {
			if (!spawns.ContainsKey (types [i])) {
				spawns [types [i]] = new Queue< Pair<float,float> > ();
			}
			spawns [types [i]].Enqueue (new Pair<float,float>(times[i],positions[i]));
			if (types [i] == -1) {
				if (GameValuesContainer.container == null) {
					GameValuesContainer.container = new GameValuesContainer ();
				}
				GameValuesContainer.container.stageDuration = times [i]+1;
			}
		}

	}

	protected float[] SpawnsTimes (){
		float[] times = new float[]{1f,2f,3f,4f,5f,6f,7f,8f,9f,10f,
			11f,12f,13f,14f,15f,16f,17f,18f,19f,20f,
			21f,22f,23f,24f,25f,26f,27f,28f,29f,30f,
			35f};
		return times;
	}
	protected int[] SpawnsTypes (){
		int[] types = new int[]{0,0,1,0,0,1,0,0,1,0,
			0,1,0,0,1,0,0,1,0,0,
			1,0,0,1,0,0,1,0,0,1,
			-1};
		return types;
	}
	protected float[] SpawnsPositions (){
		float[] positions = new float[]{0,0,1,0,0,1,0,0,1,0,
			0,1,0,0,1,0,0,1,0,0,
			1,0,0,1,0,0,1,0,0,1,
			0.5f};
		return positions;
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

	void SpawnEnemy(int enemyIndex, float position){
		float size = GetComponent<Renderer> ().bounds.size.z;
		Vector3 spawnPoint = new Vector3(0,0,(position-0.5f)*size) + GetComponent<Renderer> ().bounds.center;
		GameObject enemy = (GameObject)Instantiate (enemies [enemyIndex], spawnPoint, Quaternion.identity);
		enemy.transform.SetParent (GameValuesContainer.container.enemiesContainer.transform);
	}

	void SpawnBoss(float position){
		float size = GetComponent<Renderer> ().bounds.size.z;
		Vector3 spawnPoint = new Vector3(0,0,(position-0.5f)*size) + GetComponent<Renderer> ().bounds.center;
		Instantiate (boss, spawnPoint, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		if (GameValuesContainer.container.rhythmHandler.spawnSpot.GetComponent<AudioSource> ().isPlaying) {
			SpawnAtTimes ();
		}
	}

	protected void SpawnAtTimes(){
		float currentAudioTime = GameValuesContainer.container.rhythmHandler.spawnSpot.GetTime ();
		foreach (int key in spawns.Keys) {
				while (spawns [key].Count > 0 && spawns [key].Peek ().First <= currentAudioTime) {
				if (key == -1) {
					SpawnBoss (spawns [key].Dequeue ().Second);
				}
				else {
					SpawnEnemy (key, spawns [key].Dequeue ().Second);
				}
			}
		}
	}
}
