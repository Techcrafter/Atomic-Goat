using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagement2D : MonoBehaviour
{
	public AudioClip PlayerJumpSound;
	public AudioClip PlayerHittedSound;
	public AudioClip PlayerDiesSound;
	
	public GameObject HeadMissile;
	public AudioClip ShootHeadMissileSound;
	
	bool TurnedLeft;
	bool Grounded = true;
	bool HitCooldown;
	bool HeadMissileCooldown;
	
	int CheckGround;
	
	int HP = 3;
	GameObject Heart1;
	GameObject Heart2;
	GameObject Heart3;
	
	float LastY;
	
	GameObject LoadingText;
	
	Rigidbody2D Rigidbody;
	Animator Animator;
	
    // Start is called before the first frame update
    void Start()
    {
		Heart1 = GameObject.Find("Heart1");
		Heart2 = GameObject.Find("Heart2");
		Heart3 = GameObject.Find("Heart3");
		
		LoadingText = GameObject.Find("LoadingText");
		LoadingText.SetActive(false);
		
        Animator = gameObject.GetComponent<Animator>();
		Rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetAxis("Horizontal") > 0.0f)
		{
			if(TurnedLeft)
			{
				transform.Rotate(0.0f, -180.0f, 0.0f);
				TurnedLeft = false;
			}
			if(Grounded)
			{
				Animator.Play("PlayerWalk");
			}
			Rigidbody.velocity = new Vector2(1.5f, Rigidbody.velocity.y);
		}
		if(Input.GetAxis("Horizontal") < 0.0f)
		{
			if(!TurnedLeft)
			{
				transform.Rotate(0.0f, 180.0f, 0.0f);
				TurnedLeft = true;
			}
			if(Grounded)
			{
				Animator.Play("PlayerWalk");
			}
			Rigidbody.velocity = new Vector2(-1.5f, Rigidbody.velocity.y);
		}
		if(Input.GetAxis("Horizontal") == 0.0f && Grounded)
		{
			Animator.Play("PlayerIdle");
		}
        if(Input.GetButtonDown("Jump") && Grounded)
		{
			Grounded = false;
			LastY = transform.position.y;
			gameObject.GetComponent<AudioSource>().clip = PlayerJumpSound;
			gameObject.GetComponent<AudioSource>().Play();
			Animator.Play("PlayerJump");
			Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, 5.0f);
		}
		if(Input.GetButtonDown("Fire1"))
		{
			if(!HeadMissileCooldown)
			{
				HeadMissileCooldown = true;
				StartCoroutine(HeadMissileCooldownTimer());
				gameObject.GetComponent<AudioSource>().clip = ShootHeadMissileSound;
				gameObject.GetComponent<AudioSource>().Play();
				if(TurnedLeft)
				{
					Destroy(Instantiate(HeadMissile, new Vector3(transform.position.x - 0.4f, transform.position.y + 0.16f, 0), transform.rotation), 3);
				}
				else
				{
					Destroy(Instantiate(HeadMissile, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.16f, 0), transform.rotation), 3);
				}
			}
		}
		
		if(!Grounded)
		{
			if(transform.position.y == LastY)
			{
				CheckGround++;
				if(CheckGround == 3)
				{
					CheckGround = 0;
					Grounded = true;
				}
			}
			else
			{
				CheckGround = 0;
				LastY = transform.position.y;
			}
		}
    }
	
	IEnumerator HeadMissileCooldownTimer()
	{
		yield return new WaitForSeconds(1.0f);
		HeadMissileCooldown = false;
	}
	
	IEnumerator Hitted(int HpToLose)
	{
		if(!HitCooldown)
		{
			HitCooldown = true;
			HP = HP - HpToLose;
			if(HP <= 0)
			{
				Heart1.SetActive(false);
				Heart2.SetActive(false);
				Heart3.SetActive(false);
			}
			else if(HP == 1)
			{
				Heart1.SetActive(true);
				Heart2.SetActive(false);
				Heart3.SetActive(false);
			}
			else if(HP == 2)
			{
				Heart1.SetActive(true);
				Heart2.SetActive(true);
				Heart3.SetActive(false);
			}
			else if(HP >= 3)
			{
				Heart1.SetActive(true);
				Heart2.SetActive(true);
				Heart3.SetActive(true);
			}
			if(HP <= 0)
			{
				GameObject.Find("Canvas").GetComponent<Animator>().Play("FadeOut");
				gameObject.GetComponent<AudioSource>().clip = PlayerDiesSound;
				gameObject.GetComponent<AudioSource>().Play();
				yield return new WaitForSeconds(1.0f);
				PlayerPrefs.SetInt("RespawnScene", SceneManager.GetActiveScene().buildIndex);
				LoadingText.SetActive(true);
				Application.LoadLevel(2);
			}
			else
			{
				gameObject.GetComponent<AudioSource>().clip = PlayerHittedSound;
				gameObject.GetComponent<AudioSource>().Play();
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				yield return new WaitForSeconds(0.2f);
				gameObject.GetComponent<SpriteRenderer>().enabled = true;
				yield return new WaitForSeconds(0.2f);
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				yield return new WaitForSeconds(0.2f);
				gameObject.GetComponent<SpriteRenderer>().enabled = true;
				yield return new WaitForSeconds(0.2f);
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				yield return new WaitForSeconds(0.2f);
				gameObject.GetComponent<SpriteRenderer>().enabled = true;
				yield return new WaitForSeconds(0.2f);
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
				yield return new WaitForSeconds(0.1f);
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				yield return new WaitForSeconds(0.1f);
				gameObject.GetComponent<SpriteRenderer>().enabled = true;
			}
			HitCooldown = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		switch(collider.gameObject.tag)
		{
			case "1HpPlayerDamageObject":
				StartCoroutine(Hitted(1));
				break;
			case "Deadline":
				StartCoroutine(Hitted(9999));
				break;
		}
	}
}
