using UnityEngine;
using System.Collections;

public class gameover : MonoBehaviour 
{
	public GameObject OverFlag;

	public bool overCheck;

	bool PlayerDeath;

	void Start ()
	{
		PlayerDeath = false;
	}


	void Update ()
	{
		PlayerDeath = Player2.DeathFlag;

		if (PlayerDeath == true)
		{
			OverFlag.gameObject.SetActive (true);
			transform.position.Set (0, 0, 0);
		}
	}
}
