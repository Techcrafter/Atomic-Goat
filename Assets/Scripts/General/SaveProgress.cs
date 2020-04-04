using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
	public string VarToSaveTo;
	public int ValueToSave;
	
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt(VarToSaveTo, ValueToSave);
    }
}
