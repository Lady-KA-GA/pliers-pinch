using UnityEngine;
using System.Collections;

public class subtest : MonoBehaviour 
{
	public GameObject test;

	public bool characterInQuicksand = false;
	public bool check = false;

	void Start () 
	{
		
	}

	void Update () 
	{
		
	}




	void OnTriggerEnter2D(Collider2D collider)
	{
		Vector2 vec = test.transform.localScale;

		//string layerName = LayerMask.LayerToName(collider.gameObject.layer);
		//if (layerName == "object") 
		//{
		//	s.y *= y;
		//}

		string PlayerLayer1 = LayerMask.LayerToName(collider.gameObject.layer);
		string PlayerLayer2 = LayerMask.LayerToName(collider.gameObject.layer);

		if (PlayerLayer1 == "Player1" && PlayerLayer2 == "Player2") 
		{
			characterInQuicksand = true;
		}
		else 
		{
			characterInQuicksand = false;
		}


		test.transform.localScale = vec;
	}

}
