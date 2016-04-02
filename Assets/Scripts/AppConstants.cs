using UnityEngine;
using System;
using System.Collections;

public class AppConstants : MonoBehaviour
{
	public static string kFirebaseAppID = "helpless.firebaseIO.com";
	public static string kFirebaseSecret = "zApXtAglfl8eMAWM5y4vA5X2WdSDiOD33PW5PGkC";
	public static string kPhotonVoiceAppID = "ba55f314-02b2-4c9f-9757-67c61b1e509b";

	IFirebase fbRootRef;
	IFirebase primaryRef;

	void Awake ()
	{
		fbRootRef = Firebase.CreateNew ("https://" + kFirebaseAppID);
		primaryRef = fbRootRef.Child ("initChild");
	}

	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnEnable ()
	{
		primaryRef.ChildAdded += primaryRefChildAdded;
	}

	void OnDisable ()
	{
		primaryRef.ChildAdded -= primaryRefChildAdded;
	}

	void primaryRefChildAdded (object sender, FirebaseChangedEventArgs e)
	{
		Debug.Log ("childAdded: " + e.DataSnapshot.Key);
	}
	

}
