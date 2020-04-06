using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeGuy2DManager : MonoBehaviour
{
	int HP = 2;
	
	bool Throwing;
	bool HitCooldown;
	
	public GameObject Grenade;
	
	public AudioClip HittedSound;
	public AudioClip KilledSound;
	
    // Update is called once per frame
    void Update()
    {
        if(Random.Range(1, 150) == 1 && !Throwing)
		{
			Throwing = true;
			gameObject.GetComponent<Animator>().Play("GrenadeGuyThrowing2D");
			StartCoroutine(Cooldown());
			Destroy(Instantiate(Grenade, new Vector3(transform.position.x + 0.2f, transform.position.y + 0.2f, 0), transform.rotation), 2.4f);
		}
    }
	
	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(2.4f);
		Throwing = false;
	}
	
	IEnumerator Hitted(int HpToLose)
	{
		HitCooldown = true;
		HP = HP - HpToLose;
		if(HP <= 0)
		{
			gameObject.GetComponent<AudioSource>().clip = KilledSound;
			gameObject.GetComponent<AudioSource>().Play();
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds(0.1f);
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			yield return new WaitForSeconds(0.1f);
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds(0.1f);
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			yield return new WaitForSeconds(0.1f);
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			Destroy(gameObject);
		}
		else
		{
			gameObject.GetComponent<AudioSource>().clip = HittedSound;
			gameObject.GetComponent<AudioSource>().Play();
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds(0.2f);
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			yield return new WaitForSeconds(0.2f);
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds(0.1f);
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			yield return new WaitForSeconds(0.1f);
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds(0.1f);
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			yield return new WaitForSeconds(0.1f);
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds(0.1f);
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
		HitCooldown = false;
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		switch(collider.gameObject.tag)
		{
			case "1HpEnemyDamageObject":
				if(!HitCooldown)
				{
					Destroy(collider.gameObject);
					StartCoroutine(Hitted(1));
				}
				break;
			case "Deadline":
				StartCoroutine(Hitted(9999));
				break;
		}
	}
}
