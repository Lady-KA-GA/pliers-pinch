using UnityEngine;
using System.Collections;

public class kub : MonoBehaviour 
{
	public GameObject kub_body;
	public GameObject kub_root;
	public bool Check;

	//public bool testcheck;



	//public bool root_on;

	void Start () 
	{
		Check = false;
		//testcheck = false;
	}
		

	void Update ()
	{
		//testcheck = Player.Flag;
		if (Check == true && Input.GetKeyDown ("up")&&Input.GetKey("space")) 
		{
			Check = false;
			kub_root.GetComponent<CircleCollider2D> ().enabled = true;
			kub_body.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		}
			
/*		if(root_on == true)
		{
			kub_body.GetComponent<RigidbodyConstraints2D> () = RigidbodyConstraints2D.FreezePositionX;
		}
		root_on = kub_root.GetComponent<CircleCollider2D> ().enabled;
		root_on = RigidbodyConstraints2D.FreezePositionX;*/
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
