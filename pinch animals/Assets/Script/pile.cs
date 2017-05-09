using UnityEngine;
using System.Collections;

public class pile : MonoBehaviour 
{
	public GameObject pile_body;
	public GameObject pile_root;
	public bool Check;
	public int HP;

	void Start () 
	{
		HP = 3;
	}

	void Update () 
	{
		if (HP != 0) 
		{
			if (Check == true && Input.GetKey("space") &&(Input.GetKeyDown ("left") || Input.GetKeyDown ("right"))) 
			{
				HP -= 1;
			}
		}
		if (Check == true && HP == 0 && Input.GetKeyDown ("up")&&Input.GetKey("space")) 
		{
			Check = false;
			pile_root.GetComponent<PolygonCollider2D> ().enabled = true;
			pile_body.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		}
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		string Pliers = LayerMask.LayerToName (collider.gameObject.layer);

		if (Pliers == "pliers") 
		{
			Check = true;
		}
	}
	void OnTriggerExit2D(Collider2D collider)
	{
		Check = false;
	}
}
