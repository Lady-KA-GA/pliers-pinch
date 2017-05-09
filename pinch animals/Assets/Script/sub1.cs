using UnityEngine;
using System.Collections;

public class sub1 : MonoBehaviour 
{
	public bool check = false;

	void Start () 
	{

	}

	void Update () 
	{
		
	}




	void OnTriggerEnter2D(Collider2D collider)
	{
		string PlayerLayer1 = LayerMask.LayerToName(collider.gameObject.layer);

		if (PlayerLayer1 == "Player1") 
		{
			check = true;
		}
	}
}