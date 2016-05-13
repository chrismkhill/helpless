using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour 
{

    public Material fadeInMaterial;

    public float fadeInSeconds = 1;

    float fadeSpeed;
	// Use this for initialization
	void Start () 
    {
	    //fadeInMaterial = this.GetComponent<Material>();
        fadeSpeed = 1f / fadeInSeconds;
        
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
    }
    
    
    void FadeToBlack ()
    {
        // Lerp the colour of the texture between itself and black.
        fadeInMaterial.color = Color.Lerp(Color.clear, Color.black, fadeSpeed * Time.deltaTime);
    }
}
