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
	private float bot0UpdatedQuaternionX;
	private float bot0UpdatedQuaternionY;
	private float bot0UpdatedQuaternionZ;
	private float bot0UpdatedQuaternionW;

	private float bot1UpdatedX;
	private float bot1UpdatedZ;
	private float bot1UpdatedQuaternionX;
	private float bot1UpdatedQuaternionY;
	private float bot1UpdatedQuaternionZ;
	private float bot1UpdatedQuaternionW;

	private float bot2UpdatedX;
	private float bot2UpdatedZ;
	private float bot2UpdatedQuaternionX;
	private float bot2UpdatedQuaternionY;
	private float bot2UpdatedQuaternionZ;
	private float bot2UpdatedQuaternionW;



	//	void Awake ()
	//	{
	//		primaryRef = fbController.primaryRef;
	//		primaryRef.ValueUpdated += updatedLocationDict;
	//	}



	//	// Use this for initialization
	void Start ()
	{
		primaryRef = fbController.primaryRef;
		primaryRef.ValueUpdated += updatedLocationDict;
	}
	
	// Update is called once per frame
	void Update ()
	{
		LeanTween.move (this.gameObject, new Vector3 (updatedX, this.gameObject.transform.position.y, updatedZ), Time.smoothDeltaTime);

		//if (enemiesToMove [0] != null) {
		LeanTween.move (enemiesToMove [0], new Vector3 (bot0UpdatedX, enemiesToMove [0].transform.position.y, bot0UpdatedZ), Time.smoothDeltaTime);
		enemiesToMove [0].transform.rotation = new Quaternion (bot0UpdatedQuaternionX, bot0UpdatedQuaternionY, bot0UpdatedQuaternionZ, bot0UpdatedQuaternionW);
		//}

		//if (enemiesToMove [1] != null) {
		LeanTween.move (enemiesToMove [1], new Vector3 (bot1UpdatedX, enemiesToMove [1].transform.position.y, bot1UpdatedZ), Time.smoothDeltaTime);
		enemiesToMove [1].transform.rotation = new Quaternion (bot1UpdatedQuaternionX, bot1UpdatedQuaternionY, bot1UpdatedQuaternionZ, bot1UpdatedQuaternionW);
		//}

		//	if (enemiesToMove [2] != null) {
		LeanTween.move (enemiesToMove [2], new Vector3 (bot2UpdatedX, enemiesToMove [2].transform.position.y, bot2UpdatedZ), Time.smoothDeltaTime);
		enemiesToMove [2].transform.rotation = new Quaternion (bot2UpdatedQuaternionX, bot2UpdatedQuaternionY, bot2UpdatedQuaternionZ, bot2UpdatedQuaternionW);
		//}
		//LeanTween.move(enemiesToMove[0], new Vector3 (

	}

	void updatedLocationDict (object sender, FirebaseChangedEventArgs e)
	{

		Debug.Log ("firebase values were added: " + e.DataSnapshot.DictionaryValue.ToStringFull ());
		updatedX = float.Parse (e.DataSnapshot.DictionaryValue ["PlayerX"].ToString ());
		updatedZ = float.Parse (e.DataSnapshot.DictionaryValue ["PlayerZ"].ToString ());

		bot0UpdatedX = float.Parse (e.DataSnapshot.DictionaryValue ["bot0X"].ToString ());
		bot0UpdatedZ = float.Parse (e.DataSnapshot.DictionaryValue ["bot0Z"].ToString ());
		bot0UpdatedQuaternionX = float.Parse (e.DataSnapshot.DictionaryValue ["bot0QuaternionX"].ToString ());
		bot0UpdatedQuaternionY = float.Parse (e.DataSnapshot.DictionaryValue ["bot0QuaternionY"].ToString ());
		bot0UpdatedQuaternionZ = float.Parse (e.DataSnapshot.DictionaryValue ["bot0QuaternionZ"].ToString ());
		bot0UpdatedQuaternionW = float.Parse (e.DataSnapshot.DictionaryValue ["bot0QuaternionW"].ToString ());

		bot1UpdatedX = float.Parse (e.DataSnapshot.DictionaryValue ["bot1X"].ToString ());
		bot1UpdatedZ = float.Parse (e.DataSnapshot.DictionaryValue ["bot1Z"].ToString ());
		bot1UpdatedQuaternionX = float.Parse (e.DataSnapshot.DictionaryValue ["bot1QuaternionX"].ToString ());
		bot1UpdatedQuaternionY = float.Parse (e.DataSnapshot.DictionaryValue ["bot1QuaternionY"].ToString ());
		bot1UpdatedQuaternionZ = float.Parse (e.DataSnapshot.DictionaryValue ["bot1QuaternionZ"].ToString ());
		bot1UpdatedQuaternionW = float.Parse (e.DataSnapshot.DictionaryValue ["bot1QuaternionW"].ToString ());

		bot2UpdatedX = float.Parse (e.DataSnapshot.DictionaryValue ["bot2X"].ToString ());
		bot2UpdatedZ = float.Parse (e.DataSnapshot.DictionaryValue ["bot2Z"].ToString ());
		bot2UpdatedQuaternionX = float.Parse (e.DataSnapshot.DictionaryValue ["bot2QuaternionX"].ToString ());
		bot2UpdatedQuaternionY = float.Parse (e.DataSnapshot.DictionaryValue ["bot2QuaternionY"].ToString ());
		bot2UpdatedQuaternionZ = float.Parse (e.DataSnapshot.DictionaryValue ["bot2QuaternionZ"].ToString ());
		bot2UpdatedQuaternionW = float.Parse (e.DataSnapshot.DictionaryValue ["bot2QuaternionW"].ToString ());

	}

	void OnDisable ()
	{
		primaryRef.ValueUpdated -= updatedLocationDict;
	}
		
}
