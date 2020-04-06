using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	GameObject LoadingText;
	
    // Start is called before the first frame update
    void Start()
    {
		LoadingText = GameObject.Find("LoadingText");
        LoadingText.SetActive(false);
    }

    public void LoadScene(string SceneName)
	{
		LoadingText.SetActive(true);
		if(SceneName == "SingleplayerMenu" && PlayerPrefs.GetInt("IntroState") == 0)
		{
			SceneName = "IntroDialogue";
		}
		else if(SceneName == "SingleplayerMenu" && PlayerPrefs.GetInt("IntroState") == 1)
		{
			SceneName = "IntroDialogue2";
		}
		SceneManager.LoadScene(SceneName);
	}
	
	public void LoadRespawnScene()
	{
		LoadingText.SetActive(true);
		SceneManager.LoadScene(PlayerPrefs.GetString("RespawnScene"));
	}
	
	public void DeleteProgress()
	{
		LoadingText.SetActive(true);
		
		//Delete PlayerPrefs that are used to save the game progress
		PlayerPrefs.SetInt("IntroState", 0);
		
		SceneManager.LoadScene("MainMenu");
	}
	
	public void Quit()
	{
		LoadingText.SetActive(true);
		Application.Quit();
	}
}
