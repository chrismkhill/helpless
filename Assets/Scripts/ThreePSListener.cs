using UnityEngine;
using System.Collections;

public class ThreePSListener : MonoBehaviour
{

	public HelplessFBController fbController;
	public GameObject playerToMove;
	public GameObject[] enemiesToMove;
	private IFirebase primaryRef;
	private float updatedX;
	private float updatedZ;

	private float bot0UpdatedX;
	private float bot0UpdatedZ;
	private float bot0UpdatedEulerY;

	private float bot1UpdatedX;
	private float bot1UpdatedZ;
	private float bot1UpdatedEulerY;

	private float bot2UpdatedX;
	private float bot2UpdatedZ;
	private float bot2UpdatedEulerY;



	// Use this for initialization
	void Start ()
	{
		primaryRef = fbController.primaryRef;
		primaryRef.ValueUpdated += updatedLocationDict;
	}
	
	// Update is called once per frame
	void Update ()
	{
		LeanTween.move (playerToMove, new Vector3 (updatedX, playerToMove.transform.position.y, updatedZ), Time.smoothDeltaTime);

		if (enemiesToMove [0] != null) {
			LeanTween.move (enemiesToMove [0], new Vector3 (bot0UpdatedX, enemiesToMove [0].transform.position.y, bot0UpdatedZ), Time.smoothDeltaTime);
			LeanTween.rotateY (enemiesToMove [0], bot0UpdatedEulerY, Time.smoothDeltaTime);
		}

		if (enemiesToMove [1] != null) {
			LeanTween.move (enemiesToMove [1], new Vector3 (bot1UpdatedX, enemiesToMove [1].transform.position.y, bot1UpdatedZ), Time.smoothDeltaTime);
			LeanTween.rotateY (enemiesToMove [1], bot1UpdatedEulerY, Time.smoothDeltaTime);
		}

		if (enemiesToMove [2] != null) {
			LeanTween.move (enemiesToMove [2], new Vector3 (bot2UpdatedX, enemiesToMove [2].transform.position.y, bot2UpdatedZ), Time.smoothDeltaTime);
			LeanTween.rotateY (enemiesToMove [2], bot2UpdatedEulerY, Time.smoothDeltaTime);
		}
		//LeanTween.move(enemiesToMove[0], new Vector3 (

	}

	void updatedLocationDict (object sender, FirebaseChangedEventArgs e)
	{

		Debug.Log ("firebase values were added: " + e.DataSnapshot.DictionaryValue.ToStringFull ());
		updatedX = float.Parse (e.DataSnapshot.DictionaryValue ["X"].ToString ());
		updatedZ = float.Parse (e.DataSnapshot.DictionaryValue ["Z"].ToString ());

		bot0UpdatedX = float.Parse (e.DataSnapshot.DictionaryValue ["bot0X"].ToString ());
		bot0UpdatedZ = float.Parse (e.DataSnapshot.DictionaryValue ["bot0Z"].ToString ());
		bot0UpdatedEulerY = float.Parse (e.DataSnapshot.DictionaryValue ["bot0EulerY"].ToString ());

		bot1UpdatedX = float.Parse (e.DataSnapshot.DictionaryValue ["bot1X"].ToString ());
		bot1UpdatedZ = float.Parse (e.DataSnapshot.DictionaryValue ["bot1Z"].ToString ());
		bot1UpdatedEulerY = float.Parse (e.DataSnapshot.DictionaryValue ["bot1EulerY"].ToString ());

		bot2UpdatedX = float.Parse (e.DataSnapshot.DictionaryValue ["bot2X"].ToString ());
		bot2UpdatedZ = float.Parse (e.DataSnapshot.DictionaryValue ["bot2Z"].ToString ());
		bot2UpdatedEulerY = float.Parse (e.DataSnapshot.DictionaryValue ["bot2EulerY"].ToString ());

	}

	void OnDisable ()
	{
		primaryRef.ValueUpdated -= updatedLocationDict;
	}
		
}
