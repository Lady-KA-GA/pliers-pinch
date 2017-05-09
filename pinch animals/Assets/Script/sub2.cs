using UnityEngine;
using System.Collections;

public class sub2 : MonoBehaviour 
{
	public bool characterInQuicksand = false;

	void Start () 
	{

	}

	void Update () 
	{
		
	}




	void OnTriggerEnter2D(Collider2D collider)
	{
		string PlayerLayer2 = LayerMask.LayerToName(collider.gameObject.layer);

		if (PlayerLayer2 == "Player2") 
		{
			characterInQuicksand = true;
		}
	}
}