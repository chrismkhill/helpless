using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnCollectibles : MonoBehaviour
{

	public GameObject[] spawnPositions;
	public GameObject collectibleItem;
	public GUIManagement guiManagement;

	public int collectiblesToSpawn;
	
	// Use this for initialization
	void Start ()
	{
		guiManagement = GameObject.Find ("GUIManagement").GetComponent<GUIManagement> ();
		spawnPositions = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		guiManagement.collectiblesCount = collectiblesToSpawn;

		List<GameObject> randomSpawnPositions = new List<GameObject> ();

		while (randomSpawnPositions.Count < collectiblesToSpawn) {
			GameObject randomSpawnPosition = spawnPositions [Random.Range (0, spawnPositions.Length)];
			if (!randomSpawnPositions.Contains (randomSpawnPosition)) {
				randomSpawnPositions.Add (randomSpawnPosition);

				Instantiate (collectibleItem, randomSpawnPosition.transform.position, Quaternion.identity);
			}

		}


	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
