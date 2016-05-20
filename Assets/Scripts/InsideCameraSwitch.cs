using UnityEngine;
using System;
using System.Collections;

public class InsideCameraSwitch : MonoBehaviour
{

	public Camera firstPersonCamera;
	public Camera thirdPersonCamera;

	public event Action toggledCameraEvent;

	private int incrementer = 0;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void toggleCamera ()
	{
		thirdPersonCamera.enabled = false;
		firstPersonCamera.enabled = true;
		toggledCameraEvent ();
	}

}
