using UnityEngine;
using System.Collections;

public class pole : MonoBehaviour 
{/*
	public GameObject pole_body;
	public GameObject pole_root;
	public bool Check;

	public float HP;
	public bool Flag;

	void Start () 
	{
		Check = false;
		Flag = false;
	}

	void Update () 
	{
		HP = Player3.PowerPre;
		Flag = Player3.PressPre;
		if(Check == true && Flag==true && (HP >= 6.5 && HP <= 8.5))
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
*/
}
