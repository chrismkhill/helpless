using UnityEngine;
using System.Collections;

public class EnemyDetection : MonoBehaviour 
{

    float startTimer = 2.0f;

    bool isCollided = false;

    AudioClip audioClip;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isCollided)
        {
            startTimer -= Time.deltaTime;
        }

        if (startTimer <= 0.0f)
        {
            Application.LoadLevel("GameOver");
        }	
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FPSPlayer")
        {
            isCollided = true;
            gameObject.GetComponent<AudioSource>().Play ();


        }
    }
}
