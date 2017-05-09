using UnityEngine;
using System.Collections;

public class BottomSound : MonoBehaviour 
{
	private AudioSource sound;

	// Use this for initialization
	void Start () 
	{
		sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			sound.PlayOneShot(sound.clip);
		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			sound.PlayOneShot(sound.clip);
		}
	}
}
