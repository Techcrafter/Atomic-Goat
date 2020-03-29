using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject2D : MonoBehaviour
{
	public Transform Target;
	
	public float xDif;
	public float yDif;
	
    // Update is called once per frame
    void Update()
    {
        if(Target != null)
		{
			transform.position = new Vector3(Target.position.x  + xDif, Target.position.y + yDif, transform.position.z);
		}
    }
}
