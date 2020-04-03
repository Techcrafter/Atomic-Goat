using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForKeyToContinue : MonoBehaviour
{
	GameObject LoadingText;
	
	public int SceneToLoad;
	
    // Start is called before the first frame update
    void Start()
    {
		LoadingText = GameObject.Find("LoadingText");
		LoadingText.SetActive(false);
	}
	
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit") || Input.GetButtonDown("Cancel") || Input.GetButtonDown("Jump"))
		{
			LoadingText.SetActive(true);
			Application.LoadLevel(SceneToLoad);
		}
    }
}
