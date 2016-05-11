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


		//[Range(0, 100)]
		//public int RevealSpeed = 50;

		//	private string label01 = "Elliot…Elliot…\n\nIt’s me. It looks like I can hear you. Both of you.\n\nOur “friend” is on the other end. ";
		//"Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <smallcaps>TextMesh</smallcaps><sup><#40a0ff>Pro</color></sup><sprite=0> and Unity 4.6 & 5.x <sprite=2>";
		//private string label02 = "Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <smallcaps>TextMesh</smallcaps><sup><#40a0ff>Pro</color></sup><sprite=0> and Unity 4.6 & 5.x <sprite=1>";
		//	private string label02 = "He can see you, so he can help you here a lot more than I can. Say hi, “friend”!\n\nI have to run. I’m being tailed. I’ve got about 20 seconds before I need to run for my life";

		private TextMeshProUGUI m_textMeshPro;


		void Awake ()
		{
			// Get Reference to TextMeshPro Component if one exists; Otherwise add one.
			m_textMeshPro = gameObject.GetComponent<TextMeshProUGUI> () ?? gameObject.AddComponent<TextMeshProUGUI> ();
			//	m_textMeshPro.text = label01;
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


		}


		IEnumerator Start ()
		{

			// Force and update of the mesh to get valid information.
			m_textMeshPro.ForceMeshUpdate ();


			int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount; // Get # of Visible Character in text object
			int counter = 0;
			int visibleCount = 0;

			while (true) {
				visibleCount = counter % (totalVisibleCharacters + 1);

				m_textMeshPro.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?        

				// Once the last character has been revealed, wait 1.0 second and start over.
				if (visibleCount >= totalVisibleCharacters) {
					yield return new WaitForSeconds (1.0f);
					//m_textMeshPro.text = "The first thing you need to do is go grab some power. Need to pick up this juice, it’s a little silver accessory, or you’re going to lose your connection to our friend. I’d guess with how heavy motion-tracking and the camera feed is that you’ve got a minute plus or minus to grab the battery to stay online.";
					//m_textMeshPro.text = label02;
					yield return new WaitForSeconds (1.0f);
					//m_textMeshPro.text = label01;
					yield return new WaitForSeconds (1.0f);
				}

				counter += 1;

				yield return new WaitForSeconds (0.05f);
			}

			//Debug.Log("Done revealing the text.");     
		}

	}
}
#endif
