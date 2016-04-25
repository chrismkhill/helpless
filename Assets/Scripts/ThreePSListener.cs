using UnityEngine;
using System.Collections;

public class ThreePSListener : MonoBehaviour
{

	public HelplessFBController fbController;
	public GameObject playerToMove;
	private IFirebase rootRef;
	private float updatedX;
	private float updatedZ;

	// Use this for initialization
	void Start ()
	{
		rootRef = fbController.primaryRef;
		rootRef.ValueUpdated += updatedLocation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		LeanTween.move (playerToMove, new Vector3 (updatedX, playerToMove.transform.position.y, updatedZ), Time.smoothDeltaTime);

	}

	void updatedLocation (object sender, FirebaseChangedEventArgs e)
	{

		Debug.Log ("received location update");
		Debug.Log ("firebase values were added: " + e.DataSnapshot.DictionaryValue.ToStringFull ());
		updatedX = float.Parse (e.DataSnapshot.DictionaryValue ["X"].ToString ());
		updatedZ = float.Parse (e.DataSnapshot.DictionaryValue ["Z"].ToString ());

		Debug.Log ("received x value : " + updatedX);
		Debug.Log ("received z value : " + updatedX);

	}
		
}
