using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagement2D : MonoBehaviour
{
	public AudioClip PlayerJumpSound;
	public AudioClip PlayerDiesSound;
	
	public GameObject HeadMissile;
	public AudioClip ShootHeadMissileSound;
	
	bool turnedLeft;
	bool grounded = true;
	bool HeadMissileCooldown;
	
	int checkGround;
	
	int HP = 3;
	GameObject Heart1;
	GameObject Heart2;
	GameObject Heart3;
	
	float lastY;
	
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
			if(turnedLeft)
			{
				transform.Rotate(0.0f, -180.0f, 0.0f);
				turnedLeft = false;
			}
			if(grounded)
			{
				Animator.Play("PlayerWalk");
			}
			Rigidbody.velocity = new Vector2(1.5f, Rigidbody.velocity.y);
		}
		if(Input.GetAxis("Horizontal") < 0.0f)
		{
			if(!turnedLeft)
			{
				transform.Rotate(0.0f, 180.0f, 0.0f);
				turnedLeft = true;
			}
			if(grounded)
			{
				Animator.Play("PlayerWalk");
			}
			Rigidbody.velocity = new Vector2(-1.5f, Rigidbody.velocity.y);
		}
		if(Input.GetAxis("Horizontal") == 0.0f && grounded)
		{
			Animator.Play("PlayerIdle");
		}
        if(Input.GetButtonDown("Jump"))
		{
			if(grounded)
			{
				grounded = false;
				lastY = transform.position.y;
				gameObject.GetComponent<AudioSource>().clip = PlayerJumpSound;
				gameObject.GetComponent<AudioSource>().Play();
				Animator.Play("PlayerJump");
				Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, 5.0f);
			}
		}
		if(Input.GetButtonDown("Fire1"))
		{
			if(!HeadMissileCooldown)
			{
				HeadMissileCooldown = true;
				StartCoroutine(HeadMissileCooldownTimer());
				gameObject.GetComponent<AudioSource>().clip = ShootHeadMissileSound;
				gameObject.GetComponent<AudioSource>().Play();
				if(turnedLeft)
				{
					Destroy(Instantiate(HeadMissile, new Vector3(transform.position.x - 0.4f, transform.position.y + 0.16f, 0), transform.rotation), 3);
				}
				else
				{
					Destroy(Instantiate(HeadMissile, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.16f, 0), transform.rotation), 3);
				}
			}
		}
		
		if(!grounded)
		{
			if(transform.position.y == lastY)
			{
				checkGround++;
				if(checkGround == 3)
				{
					checkGround = 0;
					grounded = true;
				}
			}
			else
			{
				checkGround = 0;
				lastY = transform.position.y;
			}
		}
    }
	
	IEnumerator HeadMissileCooldownTimer()
	{
		yield return new WaitForSeconds(1.0f);
		HeadMissileCooldown = false;
	}
	
	IEnumerator Die()
	{
		GameObject.Find("Canvas").GetComponent<Animator>().Play("FadeOut");
		gameObject.GetComponent<AudioSource>().clip = PlayerDiesSound;
				gameObject.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1.0f);
		PlayerPrefs.SetInt("RespawnScene", SceneManager.GetActiveScene().buildIndex);
		LoadingText.SetActive(true);
		Application.LoadLevel(2);
	}
	
	void UpdateHP()
	{
		if(HP <= 0)
		{
			Heart1.SetActive(false);
			Heart2.SetActive(false);
			Heart3.SetActive(false);
			StartCoroutine(Die());
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
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		switch(collider.gameObject.tag)
		{
			case "1HpPlayerDamageObject":
				HP--;
				UpdateHP();
				break;
			case "Deadline":
				StartCoroutine(Die());
				break;
		}
	}
}
