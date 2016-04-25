using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManagement : MonoBehaviour 
{
    public int collectiblesCount = 5;
    public int collectiblesFound = 0;

    public float timerInSeconds = 300f;

    public Text scoreText;
    public Text timerText;

	// Use this for initialization
	void Start () 
    {
        scoreText.text = collectiblesFound.ToString() + "/" + collectiblesCount.ToString();

	}
	
	// Update is called once per frame
	void Update () 
    {
	    timerInSeconds -= Time.deltaTime;
        int timerMinutes = (int)timerInSeconds / 60;
        int timerSeconds = (int)timerInSeconds % 60;
        timerText.text = timerMinutes.ToString() + ":" + timerSeconds.ToString();
        
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
