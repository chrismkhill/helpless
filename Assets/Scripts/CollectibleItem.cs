using UnityEngine;
using System.Collections;

public class CollectibleItem : MonoBehaviour
{

	public GUIManagement guiManagement;
	public AudioSource pop;
	public float destroyTime = 0.1f;

	public void Start ()
	{
		guiManagement = GameObject.Find ("GUIManagement").GetComponent<GUIManagement> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Spin the collectible
		this.transform.Rotate (Vector3.down, Space.World);

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "FPSPlayer") {
			gameObject.GetComponent<AudioSource> ().Play ();
			guiManagement.collectiblesFound++;
			Debug.Log ("collectibles found count is " + guiManagement.collectiblesFound);
			Destroy (gameObject, destroyTime);
		}
		guiManagement.CheckForWin ();
	}
}
