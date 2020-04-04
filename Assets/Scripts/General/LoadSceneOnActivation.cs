using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnActivation : MonoBehaviour
{
	public int SceneToLoad;
	
    // Start is called before the first frame update
    void Start()
    {
        Application.LoadLevel(SceneToLoad);
    }
}
