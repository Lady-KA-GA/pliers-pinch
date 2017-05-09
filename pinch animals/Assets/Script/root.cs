using UnityEngine;
using System.Collections;

public class root : MonoBehaviour 
{
		public GameObject root_root;
		public bool Check;

		//public bool root_on;

		void Start () 
		{
			Check = false;
		}


		void Update ()
		{
		if (Check == true && Input.GetKeyDown ("up")&&Input.GetKey("space")) 
			{
				Check = false;
				root_root.GetComponent<BoxCollider2D> ().enabled = true;
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
