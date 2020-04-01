using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScene2D : MonoBehaviour
{
    public string TagThatTriggers;
	public int SceneToLoad;
	
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
			Application.LoadLevel(SceneToLoad);
		}
	}
}
