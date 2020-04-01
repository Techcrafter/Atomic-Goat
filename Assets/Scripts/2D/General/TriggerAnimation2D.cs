using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation2D : MonoBehaviour
{
	public string TagThatTriggers;
	public string AnimationToPlay;
	
    void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == TagThatTriggers)
		{
			gameObject.GetComponent<Animator>().Play(AnimationToPlay);
		}
	}
}
