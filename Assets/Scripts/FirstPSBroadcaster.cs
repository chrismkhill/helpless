using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FirstPSBroadcaster : MonoBehaviour
{

	public GameObject[] enemiesToTrack;
	private Transform currentTransform;
	public HelplessFBController fbController;
	private IFirebase rootRef;

	// Use this for initialization
	void Start ()
	{
	
		rootRef = fbController.primaryRef;

	}
	
	// Update is called once per frame
	void Update ()
	{

		rootRef.SetValue (createLocationEntry ());
	}


	//note: test if string for transform position components works better on receiver end for parsing.
	IDictionary<string, object> createLocationEntry ()
	{
		IDictionary <string, object> locationDictionary = new Dictionary<string, object> ();

		locationDictionary.Add ("X", this.gameObject.transform.position.x.ToString ());
		locationDictionary.Add ("Y", this.gameObject.transform.position.y.ToString ());
		locationDictionary.Add ("Z", this.gameObject.transform.position.z.ToString ());

		return locationDictionary;

	}
}
