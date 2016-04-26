using UnityEngine;
using System.Collections;

public class HelplessFBController : MonoBehaviour
{

	public IFirebase fbRootRef;
	public IFirebase primaryRef;
	// Use this for initialization
	void Start ()
	{
		fbRootRef = Firebase.CreateNew ("https://" + AppConstants.kFirebaseAppID);
		primaryRef = fbRootRef.Child ("FirstRoom");
		//primaryRef.ChildAdded += primaryRefChildAdded;
		//primaryRef.ValueUpdated += primaryRefValueUpdated;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnEnable ()
	{
		
	}

	void OnDisable ()
	{
		primaryRef.ChildAdded -= primaryRefChildAdded;
	}

	void primaryRefChildAdded (object sender, FirebaseChangedEventArgs e)
	{
		Debug.Log ("childAdded: " + e.DataSnapshot.Key);
	}

	void primaryRefValueUpdated (object sender, FirebaseChangedEventArgs e)
	{

		Debug.Log ("updated transform " + e.DataSnapshot.Key);
	}


}
