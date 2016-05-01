﻿using UnityEngine;
using System.Collections;

public class CollectibleItem : MonoBehaviour
{

	public GUIManagement guiManagement;

	public void Start ()
	{
		guiManagement = GameObject.Find ("GUIManagement").GetComponent<GUIManagement> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
        //Spin the collectible
        this.transform.Rotate(Vector3.down, Space.World);

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "FPSPlayer") {
			Destroy (gameObject);
			guiManagement.collectiblesFound++;
			Debug.Log ("collectibles found count is " + guiManagement.collectiblesFound);
		}
		guiManagement.CheckForWin ();
	}
}
