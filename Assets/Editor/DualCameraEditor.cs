using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

[CustomEditor (typeof(DualCamera)), CanEditMultipleObjects]
[Serializable]
public class DualCameraEditor : Editor 
{
	[SerializeField]
	DualCamera dualCamera;

	public bool activeDualCamera;

	
	public void OnEnable()
	{
		dualCamera = (DualCamera)target;
		
		//Storing the initital spaceType
		activeDualCamera = dualCamera.activeDualCamera;

		
		
	}

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();


		if (GUILayout.Button("Active Dual Cam"))
		{
			if (dualCamera.activeDualCamera == false)
			{
				dualCamera.Activate();
			}
			else
			{
				dualCamera.Inactive();
			}
			

		}
		
		
		
		
	}
	
	
	
	
	
	
	
	
	
	
	
	
}

