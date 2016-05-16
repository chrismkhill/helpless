// Copyright (C) 2014 - 2015 Stephan Bouchard - All Rights Reserved
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

#if UNITY_4_6 || UNITY_5

using UnityEngine;
using System.Collections;


namespace TMPro.Examples
{
    
	public class TeleType : MonoBehaviour
	{
		public string[] DialogueStrings;

		public int currentDialogueIndex = 0;

		public float SecondsBetweenCharacters = 0.07f;
		public float CharacterRateMultiplier = 0.5f;

		private bool _isStringBeingRevealed = false;
		private bool _isDialoguePlaying = false;
		private bool _isEndOfDialogue = false;

		//[Range(0, 100)]
		//public int RevealSpeed = 50;

		private string label01 = "…\n\nIt’s me. It looks like I can hear you. Both of you.\n\nOur “friend” is on the other end. ";
		//"Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <smallcaps>TextMesh</smallcaps><sup><#40a0ff>Pro</color></sup><sprite=0> and Unity 4.6 & 5.x <sprite=2>";
		//private string label02 = "Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <smallcaps>TextMesh</smallcaps><sup><#40a0ff>Pro</color></sup><sprite=0> and Unity 4.6 & 5.x <sprite=1>";
		private string label02 = "He can see you, so he can help you here a lot more than I can. Say hi, “friend”!\n\nI have to run. I’m being tailed. I’ve got about 20 seconds before I need to run for my life";

		//Wake up! You're one clumsy fuck bro. You busted your suit and we're fucked.
		//We might have a chance if you pick up the five fuel cells scattered around the joint.

		//	"Your man is watching from above. He can see you and guide you to the fuel cells. Start talking to each other! Avoid the bots! He will tell you."
		private TextMeshProUGUI m_textMeshPro;


		void Awake ()
		{
			// Get Reference to TextMeshPro Component if one exists; Otherwise add one.
			m_textMeshPro = gameObject.GetComponent<TextMeshProUGUI> () ?? gameObject.AddComponent<TextMeshProUGUI> ();
			//	m_textMeshPro.text = label01;
			//m_textMeshPro.text = DialogueStrings [stringIndex];
			m_textMeshPro.enableWordWrapping = true;
			m_textMeshPro.alignment = TextAlignmentOptions.Top;



			if (GetComponentInParent (typeof(Canvas)) as Canvas == null) {
				GameObject canvas = new GameObject ("Canvas", typeof(Canvas));
				gameObject.transform.SetParent (canvas.transform);
				canvas.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceOverlay;

				// Set RectTransform Size
				gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (500, 300);
				m_textMeshPro.fontSize = 48;
			}

			StartCoroutine (StartDialogue ());
		}

		void Update ()
		{

			if (_isEndOfDialogue) {

				m_textMeshPro.text = "";
				StopAllCoroutines ();
			}
		}


		IEnumerator StartOldLineMethod (int increment)
		{
			m_textMeshPro.canvasRenderer.SetAlpha (0);
			m_textMeshPro.text = DialogueStrings [increment];

			Debug.Log ("increment is " + increment.ToString ());
			m_textMeshPro.ForceMeshUpdate ();

			int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount; // Get # of Visible Character in text object
			int counter = 0;
			int visibleCount = 0;

			while (true) {
				m_textMeshPro.canvasRenderer.SetAlpha (1);
				visibleCount = counter % (totalVisibleCharacters + 1);

				m_textMeshPro.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?        

				// Once the last character has been revealed, wait 1.0 second and start over.
				if (visibleCount >= totalVisibleCharacters) {
					yield return new WaitForSeconds (1.0f);
					//m_textMeshPro.text = DialogueStrings [stringIndex];
					yield return new WaitForSeconds (1.0f);
					//m_textMeshPro.text = label01;


					yield return new WaitForSeconds (1.0f);
					//currentDialogueIndex++;
					//
					_isStringBeingRevealed = false;
					yield break;
					//StopCoroutine (StartOldLineMethod (currentDialogueIndex - 1));


				} 

				counter += 1;

				yield return new WaitForSeconds (0.05f);


			}

			//Debug.Log("Done revealing the text.");     
		}

	

		private IEnumerator StartDialogue ()
		{
			int dialogueLength = DialogueStrings.Length;
		
			while (currentDialogueIndex < dialogueLength || !_isStringBeingRevealed) {
				if (!_isStringBeingRevealed) {
					_isStringBeingRevealed = true;
					//StartCoroutine (DisplayString (DialogueStrings [currentDialogueIndex++]));
					//StartCoroutine (RevealDialogueSequence (DialogueStrings [0]));
					StartCoroutine (StartOldLineMethod (currentDialogueIndex++));
					if (currentDialogueIndex >= dialogueLength) {
						_isEndOfDialogue = true;
					} else {
						//StartCoroutine (RevealDialogueSequence (DialogueStrings [currentDialogueIndex++]));
						//StartCoroutine (StartOldLineMethod (1));
					}
				}
		
				yield return 0;
			}
		

		
			_isEndOfDialogue = false;
			_isDialoguePlaying = false;
		}

		private IEnumerator DisplayString (string stringToDisplay)
		{
			int stringLength = stringToDisplay.Length;

			int currentCharacterIndex = 0;
		
			m_textMeshPro.canvasRenderer.SetAlpha (0);
			m_textMeshPro.text = stringToDisplay;
			m_textMeshPro.ForceMeshUpdate ();
			m_textMeshPro.text = "";

			while (currentCharacterIndex < stringLength) {
				m_textMeshPro.canvasRenderer.SetAlpha (1);
				m_textMeshPro.text += stringToDisplay [currentCharacterIndex];
				currentCharacterIndex++;
		
				if (currentCharacterIndex < stringLength) {
					
					yield return new WaitForSeconds (SecondsBetweenCharacters);

				} else {
					yield return new WaitForSeconds (1.0f);
					m_textMeshPro.text = "";
					break;
				}
			}
		
		

		
			_isStringBeingRevealed = false;

		}

	}



}
#endif
