using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement2D : MonoBehaviour
{
	GameObject HeadMissile;
	
	bool turnedLeft;
	bool grounded = true;
	bool HeadMissileCooldown;
	
	int checkGround;
	
	float lastY;
	
	Rigidbody2D Rigidbody;
	Animator Animator;
	
    // Start is called before the first frame update
    void Start()
    {
		HeadMissile = GameObject.Find("PlayerHeadMissile");
		
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
			Animator.Play("PlayerWalk");
			Rigidbody.velocity = new Vector2(1.5f, Rigidbody.velocity.y);
		}
		if(Input.GetAxis("Horizontal") < 0.0f)
		{
			if(!turnedLeft)
			{
				transform.Rotate(0.0f, 180.0f, 0.0f);
				turnedLeft = true;
			}
			Animator.Play("PlayerWalk");
			Rigidbody.velocity = new Vector2(-1.5f, Rigidbody.velocity.y);
		}
        if(Input.GetButtonDown("Jump"))
		{
			if(grounded)
			{
				grounded = false;
				lastY = transform.position.y;
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
				Destroy(Instantiate(HeadMissile, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.16f, 0), Quaternion.identity), 3);
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
}
