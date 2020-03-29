using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
	GameObject LoadingText;
	
	public int levelToLoad;
	
    // Start is called before the first frame update
    void Start()
    {
		LoadingText = GameObject.Find("LoadingText");
		LoadingText.SetActive(false);
	}
	
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit"))
		{
			LoadingText.SetActive(true);
			Application.LoadLevel(levelToLoad);
		}
    }
}
