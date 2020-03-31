using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirBomber2DManager : MonoBehaviour
{
	bool Dropping;
	
	public GameObject AirBomb;
	
	AudioClip NoiseSound;
	public AudioClip AirBombDropWarningSound;
	
    // Start is called before the first frame update
    void Start()
    {
        NoiseSound = gameObject.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(1, 425) == 1 && !Dropping)
		{
			Dropping = true;
			gameObject.GetComponent<AudioSource>().clip = AirBombDropWarningSound;
			gameObject.GetComponent<AudioSource>().Play();
			StartCoroutine(WaitForWarningFinished());
		}
    }
	
	IEnumerator WaitForWarningFinished()
	{
		yield return new WaitForSeconds(2.175f);
		Destroy(Instantiate(AirBomb, new Vector3(transform.position.x, transform.position.y - 0.5f, 0), transform.rotation), 1.9f);
		Dropping = false;
		gameObject.GetComponent<AudioSource>().clip = NoiseSound;
		gameObject.GetComponent<AudioSource>().Play();
	}
}
