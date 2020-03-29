using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
	GameObject LoadingText;
	
    // Start is called before the first frame update
    void Start()
    {
		LoadingText = GameObject.Find("LoadingText");
		LoadingText.SetActive(false);
		
        if(PlayerPrefs.GetInt("IntroCompleted") == 0)
		{
			LoadingText.SetActive(true);
			Application.LoadLevel(1);
		}
    }
}
