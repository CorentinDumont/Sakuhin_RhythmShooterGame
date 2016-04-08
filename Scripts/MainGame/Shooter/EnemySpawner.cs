// script used to spawn enemies and asteroids
// attached to an object not visible on the screen, at the top of the playing field

using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	private bool canGen = true;
	public GameObject[] enemies; // ennemies that can be generated (ships, asteroids...)

	IEnumerator GenerateEnemies() // randomly generates enemies
	{
		yield return new WaitForSeconds (Random.Range (0.5f, 2.5f));
		Vector3 size = GetComponent<Renderer> ().bounds.size;
		float boundInf = this.transform.position.z - size.z / 2;
		float boundSup = this.transform.position.z + size.z / 2;
		Vector3 spawnPoint = new Vector3(this.transform.position.x, this.transform.position.y, Random.Range(boundInf, boundSup));
		Instantiate (enemies[Random.Range (0, enemies.Length)], spawnPoint, Quaternion.identity);
		canGen = true;
	}

	// Update is called once per frame
	void Update () {
		if (canGen)
		{
			canGen = false;
			StartCoroutine (GenerateEnemies());
		}
	}
}
