using UnityEngine;
using System.Collections;

public class pile : MonoBehaviour 
{
	public GameObject pile_body;
	public GameObject pile_root;
	public bool Check;

	public float HP;
	public bool Flag;

	void Start () 
	{
		Check = false;
		Flag=false;
	}

	void Update () 
	{
		HP = Player2.PowerPre;
		Flag = Player2.PressPre;
 
		if (Check == true && Flag == true && (HP >= 3.5 && HP <= 5.5)) 
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
