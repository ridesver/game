using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dMAn;


	// Use this for initialization
	void Start () {
        dMAn = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name=="Player")
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                dMAn.ShowBox(dialogue);
            }
        }
    }
}
