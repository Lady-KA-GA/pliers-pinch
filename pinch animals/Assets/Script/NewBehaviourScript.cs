using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour 
{
	public GameObject pole_body;
	public GameObject pole_root1;
	public bool Check;
	public bool check2;
	public int HP;

	void Start ()
	{
		Check = false;

		check2 = false;
		HP = 3;
	}

	void Update ()
	{
		Vector2 pole_body_vec = pole_body.GetComponent<Transform> ().transform.position;

		if (HP != 0)
		{
			if (Check == true)
			{
				pole_root1.GetComponent<BoxCollider2D> ().enabled = true;
			}
			if(check2 == true && (Input.GetKeyDown("left")||Input.GetKeyDown("right")))
			{
				HP -= 1;
			}
		}

		if (check2 == true && HP == 0 && Input.GetKeyDown ("up"))
		{
			pole_body_vec.y += 0.6f;
		}
		pole_body.GetComponent<Transform> ().transform.position = pole_body_vec;
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		string Pliers = LayerMask.LayerToName (collider.gameObject.layer);

		if (Pliers == "pliers")
		{
			check2 = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		string Pole = LayerMask.LayerToName (collider.gameObject.layer);

		if (Pole == "pole")
		{
			Check = true;
		}
	}
}
