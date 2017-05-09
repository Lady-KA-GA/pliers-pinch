using UnityEngine;
using System.Collections;

public class clear : MonoBehaviour 
{
	public GameObject poleFlag;
	public GameObject kubFlag;
	public GameObject pileFlag;
	public GameObject clearF;

	public GameObject clearFlag_body;
	public GameObject clearFlag_root;

	public bool Check;

	void Start ()
	{
		Check = false;
	}


	void Update ()
	{
		bool PoF = poleFlag.GetComponent<BoxCollider2D> ().enabled;
		bool PiF = pileFlag.GetComponent<PolygonCollider2D> ().enabled;
		bool KuF = kubFlag.GetComponent<CircleCollider2D> ().enabled;
	
		if (PoF == true && PiF == true && KuF == true) 
		{
			clearF.SetActive (true);
		}

		//Vector2 vec = new Vector2 (kub_body.transform.position.x, kub_body.transform.position.y + 0.3f);
		//testcheck = Player.Flag;
		if (Check == true && Input.GetKeyDown ("up")&&Input.GetKey("space")) 
		{
			Check = false;
			clearFlag_root.GetComponent<BoxCollider2D> ().enabled = true;
			clearFlag_body.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
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
