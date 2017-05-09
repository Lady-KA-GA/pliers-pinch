using UnityEngine;
using System.Collections;

public class pole_Test : MonoBehaviour 
{
		public GameObject pole_body;
		public GameObject pole_root;
		public bool Exit;//抜ける
		public bool Touch;//触る

		public int HP;

		void Start () 
		{
			HP = 3;
			Exit = false;
			Touch = false;
		}

		void Update () 
		{
			Vector2 pole_body_vec = pole_body.GetComponent<Transform> ().transform.position;

			if (HP != 0) 
			{
				if(Touch == true && (Input.GetKeyDown("left")||Input.GetKeyDown("right")))
				{
					HP -= 1;
				}
			}
			if (Touch == true && HP == 0 && Input.GetKeyDown ("up"))
			{
				Touch = false;
				pole_root.GetComponent<BoxCollider2D> ().enabled = true;
				pole_body.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			}
			pole_body.GetComponent<Transform> ().transform.position = pole_body_vec;
		}

		void OnTriggerStay2D(Collider2D collider)
		{
			string Pliers = LayerMask.LayerToName (collider.gameObject.layer);

			if (Pliers == "pliers") 
			{
				Touch = true;
			}
		}

		void OnTriggerExit2D(Collider2D collider)
		{
			Exit = false;
		}

	}