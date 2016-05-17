using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour 
{

    public Material fadeInMaterial;
    public GameObject fadePlane;

    public float fadeInSeconds = 1;

    float fadeSpeed;
	// Use this for initialization
	void Awake () 
    {
        fadeSpeed = 1f / fadeInSeconds;
        fadePlane = this.gameObject;
        fadeInMaterial.color = Color.black;

        
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        FadeToClear();
	}

    void FadeToClear ()
    {
        // Lerp the colour of the texture between itself and transparent.
        fadeInMaterial.color = Color.Lerp(fadeInMaterial.color, Color.clear, fadeSpeed * Time.deltaTime);

        if (fadeInMaterial.color.a < .1f)
        {
            fadePlane.SetActive(false);
        }
    }
    
    
    void FadeToBlack ()
    {
        // Lerp the colour of the texture between itself and black.
        fadeInMaterial.color = Color.Lerp(Color.clear, Color.black, fadeSpeed * Time.deltaTime);
    }
}
