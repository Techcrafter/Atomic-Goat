using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSprite2D : MonoBehaviour
{
    public string TagThatTriggers;
	public Sprite SpriteToChangeTo;
	
    void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == TagThatTriggers)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = SpriteToChangeTo;
		}
	}
}
