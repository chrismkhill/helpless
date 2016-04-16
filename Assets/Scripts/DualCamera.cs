using UnityEngine;
using System.Collections;

public class DualCamera : MonoBehaviour 
{
	

	public Camera playerCamera;

	public Camera godCamera; 

	public bool activeDualCamera;



	public void Update()
	{
		if (activeDualCamera)
		{
			godCamera.transform.position = new Vector3(playerCamera.transform.position.x, godCamera.transform.position.y, playerCamera.transform.position.z);
		}
	}


	public void Activate()
	{
		activeDualCamera = true;
		playerCamera.rect = new Rect(0f, 0f, .5f, 1f);
		godCamera.rect = new Rect(.5f, 0f, .5f, 1f);

		godCamera.enabled = true;

	}



	public void Inactive()
	{
		activeDualCamera = false;
		playerCamera.rect = new Rect(0f, 0f, 1f, 1f);
		godCamera.rect = new Rect(0f, 0f, 1f, 1f);
		godCamera.enabled = false;
	}




}
