using UnityEngine;
using System.Collections;

public class SpawnCollectibles : MonoBehaviour 
{

	public GameObject[] spawnPositions;
    public GameObject collectibleItem; 
    public GUIManagement guiManagement;
	
	// Use this for initialization
	void Start () 
	{
        guiManagement = GameObject.Find("GUIManagement").GetComponent<GUIManagement>();
        spawnPositions = GameObject.FindGameObjectsWithTag("SpawnPoint");
        guiManagement.collectiblesCount = spawnPositions.Length;


        foreach (GameObject spawnPosition in spawnPositions)
        {
            Instantiate(collectibleItem, spawnPosition.transform.position, Quaternion.identity);
        }

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
