using UnityEngine;
using System.Collections;

public class kub : MonoBehaviour 
{
	public GameObject kub_body;
	public GameObject kub_root;

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
			vertical = 20;
			kub_body.GetComponent<Rigidbody2D> ().velocity = new Vector3 (kub_body.GetComponent<Rigidbody2D> ().velocity.x, vertical, 0);
			kub_root.GetComponent<CircleCollider2D> ().enabled = true;
			kub_body.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		}
	}
}
