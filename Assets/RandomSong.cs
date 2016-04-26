using UnityEngine;
using System.Collections;

public class RandomSong : MonoBehaviour
{

	public AudioSource[] songCollection;

	// Use this for initialization
	void Start ()
	{
		GetRandomMusic ();
	}

	void GetRandomMusic ()
	{

		AudioSource randomSong = songCollection [Random.Range (0, songCollection.Length)];
		randomSong.Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
