using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
	GameObject LoadingText;
	
    // Start is called before the first frame update
    void Start()
    {
		LoadingText = GameObject.Find("LoadingText");
        LoadingText.SetActive(false);
    }

    public void LoadScene(int BuildIndex)
	{
		LoadingText.SetActive(true);
		if(BuildIndex == 8 && PlayerPrefs.GetInt("IntroState") == 0)
		{
			BuildIndex = 3;
		}
		else if(BuildIndex == 8 && PlayerPrefs.GetInt("IntroState") == 1)
		{
			BuildIndex = 6;
		}
		Application.LoadLevel(BuildIndex);
	}
	
	public void LoadRespawnScene()
	{
		LoadingText.SetActive(true);
		Application.LoadLevel(PlayerPrefs.GetInt("RespawnScene"));
	}
	
	public void Quit()
	{
		Application.Quit();
	}
}
