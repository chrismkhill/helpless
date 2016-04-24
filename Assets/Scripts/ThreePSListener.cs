using UnityEngine;
using System.Collections;

public class ThreePSListener : MonoBehaviour
{

	public HelplessFBController fbController;
	public GameObject playerToMove;
	private IFirebase rootRef;
	private float updatedX;
	private float updatedY;
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
		float tryingx = float.Parse (e.DataSnapshot.DictionaryValue ["X"].ToString ());
		Debug.Log ("received x value : " + tryingx);
		updatedX = tryingx;
		updatedZ = float.Parse (e.DataSnapshot.DictionaryValue ["Z"].ToString ());
			
		//Debug.Log ("new X value is " + (float.TryParse (e.DataSnapshot.DictionaryValue ["X"].ToString ()).ToString ()));

		if (e.DataSnapshot.DictionaryValue ["X"] != null) {
			updatedX = (float)e.DataSnapshot.DictionaryValue ["X"];
			updatedZ = (float)e.DataSnapshot.DictionaryValue ["Z"];
			Debug.Log ("got x value: " + updatedX);
			Debug.Log ("got z value: " + updatedZ);
		}



	}

	void OnGUI ()
	{

//		GUI.Box(new Rect(Screen.width - 110 , 10 ,100 ,90), "Received Loc?");
//		if(GUI.Button(new Rect(Screen.width - 100 , 40 ,80, 20), updatedX))
//			//anim.SetBool ("Next", true);
//		if(GUI.Button(new Rect(Screen.width - 100 , 70 ,80, 20), updatedZ))
//			//anim.SetBool ("Back", true);

	}


}
