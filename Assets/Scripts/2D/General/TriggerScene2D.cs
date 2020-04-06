using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScene2D : MonoBehaviour
{
    public string TagThatTriggers;
	public string SceneToLoad;
	
	GameObject LoadingText;
	
	void Awake()
	{
		LoadingText = GameObject.Find("LoadingText");
	}
	
    void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == TagThatTriggers)
		{
			LoadingText.SetActive(true);
			SceneManager.LoadScene(SceneToLoad);
		}
	}
}
