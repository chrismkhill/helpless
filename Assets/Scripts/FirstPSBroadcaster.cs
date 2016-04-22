using UnityEngine;
using System.Collections;


public class FirstPSBroadcaster : MonoBehaviour
{

	private Transform currentTransform;
	public HelplessFBController fbController;
	private IFirebase rootRef;

	// Use this for initialization
	void Start ()
	{
	
		rootRef = fbController.primaryRef;
//		firebaseRoom = new IFirebase ();

	}
	
	// Update is called once per frame
	void Update ()
	{

		currentTransform = this.gameObject.transform;

		//rootRef.
	}
}
