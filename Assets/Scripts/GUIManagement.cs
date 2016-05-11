using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GUIManagement : MonoBehaviour
{
	public int collectiblesCount = 5;
	public int collectiblesFound = 0;

	public float timerInSeconds = 180f;

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI timerText;

	// Use this for initialization
	void Start ()
	{
		scoreText.text = collectiblesFound.ToString () + "/" + collectiblesCount.ToString ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		timerInSeconds -= Time.deltaTime;
		int timerMinutes = (int)timerInSeconds / 60;
		int timerSeconds = (int)timerInSeconds % 60;
		string zeroString = "";
		if (timerSeconds < 10) {
			zeroString = "0";
		}
			
		timerText.text = timerMinutes.ToString () + ":" + zeroString + timerSeconds.ToString ();
		scoreText.text = collectiblesFound.ToString () + "/" + collectiblesCount.ToString ();

		if (timerInSeconds <= 0) {
			GameOver ();
		}
        
	}

	public void CheckForWin ()
	{
//        scoreText.text = collectiblesFound.ToString() + "/" + collectiblesCount.ToString();
//        if (collectiblesFound == collectiblesCount)
//        {
//            Application.LoadLevel(0);
//        }
	}

	public void GameOver ()
	{
		Application.LoadLevel ("GameOver");
	}
}
