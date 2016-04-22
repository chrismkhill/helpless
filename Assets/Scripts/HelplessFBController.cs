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
		primaryRef = fbRootRef.Child ("initChild");
		primaryRef.ChildAdded += primaryRefChildAdded;
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

	public void primaryRefChildAdded (object sender, FirebaseChangedEventArgs e)
	{
		Debug.Log ("childAdded: " + e.DataSnapshot.Key);

	}


}
