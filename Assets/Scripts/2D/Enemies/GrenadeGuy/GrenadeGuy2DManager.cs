using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeGuy2DManager : MonoBehaviour
{
	bool throwing;
	
	public GameObject Grenade;
	
    // Update is called once per frame
    void Update()
    {
        if(Random.Range(1, 300) == 1 && !throwing)
		{
			throwing = true;
			gameObject.GetComponent<Animator>().Play("GrenadeGuyThrowing2D");
			StartCoroutine(Cooldown());
			Destroy(Instantiate(Grenade, new Vector3(transform.position.x + 0.2f, transform.position.y + 0.2f, 0), transform.rotation), 2.4f);
		}
    }
	
	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(2.4f);
		throwing = false;
	}
}
