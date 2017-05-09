using UnityEngine;
using System.Collections;

public class kusa : MonoBehaviour 
{
	public GameObject block;
	public bool Quick;
	public int HP;

	void Start () 
	{
		HP = 3;
	}


	void Update () 
	{
	/*	Player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Player.GetComponent<Rigidbody2D> ().velocity.x, vertical);
		Pinch.GetComponent<CircleCollider2D> ().enabled = true;
	*/	
		if (HP != 0)
		{
			if (Quick == true && (Input.GetKeyDown ("left") || Input.GetKeyDown ("right"))) 
			{
				HP -= 1;
			}
			if (Quick == true && HP == 0 && Input.GetKey ("up")) 
			{
				Quick = false;
				block.GetComponent<BoxCollider2D> ().enabled = true;
			}
		}



	}

	void OnTriggerStay2D(Collider2D collider)
	{
		string Pliers = LayerMask.LayerToName(collider.gameObject.layer);

		if (Pliers == "pliers") {
			/*if (Input.GetKey (KeyCode.Space)) {*/
				Quick = true;
			/*}*/
		}
	}
	void OnTriggerExit2D(Collider2D collider)
	{
		Quick = false;
	}
}