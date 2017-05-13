using UnityEngine;
using System.Collections;

public class sliderPos : MonoBehaviour 
{
	public GameObject player;

	void Start () 
	{

	}

	void Update ()
	{
		//double pos = player.transform.position.x * 60;
		transform.position = new Vector3 (player.transform.position.x * 60, transform.position.y, -10);

/*		if (transform.position.x < 0)
		{
			transform.position = new Vector3 (0, transform.position.y, -10);
		}

		if (transform.position.x >= 45)
		{
			transform.position = new Vector3 (45, 20, -10);
		}*/
	}
}