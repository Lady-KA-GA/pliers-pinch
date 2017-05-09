using UnityEngine;
using System.Collections;

public class pole : MonoBehaviour 
{
	public GameObject pole_body;
	public GameObject pole_root;
	public bool Check;

	public int HP;

	void Start () 
	{
		HP = 3;
		Check = false;
	}

	void Update () 
	{
		if (HP != 0) 
		{
			if(Check == true && Input.GetKey("space") && (Input.GetKeyDown("left")||Input.GetKeyDown("right")))
			{
				HP -= 1;
			}
		}

		if (Check == true && HP == 0 && Input.GetKeyDown ("up")&&Input.GetKey("space"))
		{
			Check = false;
			pole_root.GetComponent<BoxCollider2D> ().enabled = true;
			pole_body.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
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
