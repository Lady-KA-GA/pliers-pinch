using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour 
{

	public GameObject player;

	void Start () 
	{

	}

	void Update ()
	{
		transform.position = new Vector3 (player.transform.position.x, 0, -10);
	
		if (transform.position.x < -20)
		{
			transform.position = new Vector3 (-20, 0, -10);
		}

	}
}