using UnityEngine;
using System.Collections;

public class MaterialToggler : MonoBehaviour
{

	public Material materialToSwitchTo;
	private Material originalMaterial;
	public InsideCameraSwitch cSwitch;
	public bool onOffSwitch = false;

	// Use this for initialization
	void Start ()
	{
		originalMaterial = this.gameObject.GetComponent<Renderer> ().materials [0];
		cSwitch.toggledCameraEvent += switchMaterial;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (onOffSwitch) {
			switchMaterial ();
		}
	}

	void switchMaterial ()
	{
		if (this.gameObject.GetComponent<Renderer> ().materials [0] != materialToSwitchTo) {

			this.gameObject.GetComponent<Renderer> ().materials [0] = materialToSwitchTo;
		} else {
			this.gameObject.GetComponent<Renderer> ().materials [0] = originalMaterial;
		}
	}
}
