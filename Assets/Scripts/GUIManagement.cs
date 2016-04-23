using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManagement : MonoBehaviour 
{
    public int collectiblesCount = 5;
    public int collectiblesFound = 0;

    public Text scoreText;

	// Use this for initialization
	void Start () 
    {
        scoreText.text = collectiblesFound.ToString() + "/" + collectiblesCount.ToString();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void CheckForWin()
    {
        scoreText.text = collectiblesFound.ToString() + "/" + collectiblesCount.ToString();
        if (collectiblesFound == collectiblesCount)
        {
            Application.LoadLevel(0);
        }
    }
}
