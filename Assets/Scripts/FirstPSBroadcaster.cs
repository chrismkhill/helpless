﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FirstPSBroadcaster : MonoBehaviour
{

	public GameObject[] enemiesToTrack;
	private Transform currentTransform;
	public HelplessFBController fbController;
	private IFirebase primaryRef;

	// Use this for initialization
	void Start ()
	{
		primaryRef = fbController.primaryRef;
		//bot0Ref = primaryRef.Child ("Bot0Info");

        
	}
	
	// Update is called once per frame
	void Update ()
	{
		primaryRef.SetValue (createLocationEntry ());

		//bot1Ref.SetValue (getBotTransformInfo (1));
		//bot2Ref.SetValue (getBotTransformInfo (2));
	}


	//note: test if string for transform position components works better on receiver end for parsing.
	IDictionary<string, object> createLocationEntry ()
	{
		IDictionary <string, object> locationDictionary = new Dictionary<string, object> ();

		locationDictionary.Add ("PlayerX", this.gameObject.transform.position.x.ToString ());
		locationDictionary.Add ("PlayerY", this.gameObject.transform.position.y.ToString ());
		locationDictionary.Add ("PlayerZ", this.gameObject.transform.position.z.ToString ());

		locationDictionary.Add ("bot0X", enemiesToTrack [0].transform.position.x.ToString ());
		locationDictionary.Add ("bot0Y", enemiesToTrack [0].transform.position.y.ToString ());
		locationDictionary.Add ("bot0Z", enemiesToTrack [0].transform.position.z.ToString ());
        locationDictionary.Add ("bot0QuaternionX", enemiesToTrack [0].transform.rotation.x.ToString ()); 
        locationDictionary.Add ("bot0QuaternionY", enemiesToTrack [0].transform.rotation.y.ToString ()); 
        locationDictionary.Add ("bot0QuaternionZ", enemiesToTrack [0].transform.rotation.z.ToString ());
        locationDictionary.Add ("bot0QuaternionW", enemiesToTrack [0].transform.rotation.w.ToString ());

		locationDictionary.Add ("bot1X", enemiesToTrack [1].transform.position.x.ToString ());
		locationDictionary.Add ("bot1Y", enemiesToTrack [1].transform.position.y.ToString ());
		locationDictionary.Add ("bot1Z", enemiesToTrack [1].transform.position.z.ToString ());
        locationDictionary.Add ("bot1QuaternionX", enemiesToTrack [1].transform.rotation.x.ToString ()); 
        locationDictionary.Add ("bot1QuaternionY", enemiesToTrack [1].transform.rotation.y.ToString ()); 
        locationDictionary.Add ("bot1QuaternionZ", enemiesToTrack [1].transform.rotation.z.ToString ());
        locationDictionary.Add ("bot1QuaternionW", enemiesToTrack [1].transform.rotation.w.ToString ());

		locationDictionary.Add ("bot2X", enemiesToTrack [2].transform.position.x.ToString ());
		locationDictionary.Add ("bot2Y", enemiesToTrack [2].transform.position.y.ToString ());
		locationDictionary.Add ("bot2Z", enemiesToTrack [2].transform.position.z.ToString ());
        locationDictionary.Add ("bot2QuaternionX", enemiesToTrack [2].transform.rotation.x.ToString ()); 
        locationDictionary.Add ("bot2QuaternionY", enemiesToTrack [2].transform.rotation.y.ToString ()); 
        locationDictionary.Add ("bot2QuaternionZ", enemiesToTrack [2].transform.rotation.z.ToString ());
        locationDictionary.Add ("bot2QuaternionW", enemiesToTrack [2].transform.rotation.w.ToString ());

		return locationDictionary;

	}

	// to automate later, going with quick and dirty method above
	IDictionary <string, object> getBotTransformInfo (int botIndex)
	{

		GameObject bot = enemiesToTrack [botIndex];

		IDictionary <string, object> botTransformInfo = new Dictionary<string, object> ();
		botTransformInfo.Add (("bot" + botIndex.ToString () + "X"), bot.transform.position.x.ToString ());
		botTransformInfo.Add (("bot" + botIndex.ToString () + "Y"), bot.transform.position.y.ToString ());
		botTransformInfo.Add (("bot" + botIndex.ToString () + "Z"), bot.transform.position.z.ToString ());
		botTransformInfo.Add (("bot" + botIndex.ToString () + "EulerX"), bot.transform.rotation.x.ToString ());	
		botTransformInfo.Add (("bot" + botIndex.ToString () + "EulerY"), bot.transform.rotation.y.ToString ());	
		botTransformInfo.Add (("bot" + botIndex.ToString () + "EulerZ"), bot.transform.rotation.z.ToString ());	

		return botTransformInfo;
	}
}
