using UnityEngine;
using System.Collections;

public class pile : MonoBehaviour 
{
	public GameObject pile_body;
	public GameObject pile_root;

	int horizon;
	int vertical;

	void Start()
	{
		horizon = 0;

		vertical = 0;
	}
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			horizon = 30;
			vertical = 20;
			pile_body.GetComponent<Rigidbody2D> ().velocity = new Vector3 (horizon, vertical, 0);
			pile_root.GetComponent<PolygonCollider2D> ().enabled = true;
			pile_body.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		}
	}
}
