using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	private bool canGen = true;
	public GameObject[] enemies;

	IEnumerator GenerateEnemies()
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
