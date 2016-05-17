using UnityEngine;
using System.Collections;

public class FootStepSound : MonoBehaviour
{

	public float stepRate = 0.5f;
	public float stepCoolDown;
	public AudioClip footStepSound;
	private AudioSource source;

	void Start ()
	{

		source = this.gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update ()
	{
		stepCoolDown -= Time.deltaTime;
		if ((Input.GetAxis ("Horizontal") != 0f || Input.GetAxis ("Vertical") != 0f) && stepCoolDown < 0f) {
			source.pitch = 1f + Random.Range (-0.2f, 0.2f);
			source.PlayOneShot (footStepSound, 0.9f);
			stepCoolDown = stepRate;
		}
	}
}
