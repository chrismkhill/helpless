using UnityEngine;
using System.Collections;

public class CollectibleItem : MonoBehaviour {

    public GUIManagement guiManagement;

    public void Start()
    {
        guiManagement = GameObject.Find("GUIManagement").GetComponent<GUIManagement>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "FPSPlayer")
        {
            Destroy(gameObject);
            guiManagement.collectiblesFound ++;
        }
        guiManagement.CheckForWin();
    }
}
