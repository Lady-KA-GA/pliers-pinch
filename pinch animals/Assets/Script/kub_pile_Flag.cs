using UnityEngine;
using System.Collections;

public class kub_pile_Flag : MonoBehaviour 
{
	public GameObject kub0;
	public GameObject kub1;
	public GameObject kub2;
	public GameObject kub3;


	public GameObject pileFlag;

	public GameObject ClearFlag;

	public static bool Check;

	void Start ()
	{
		Check = false;
	}


	void Update ()
	{
		bool PiF = pileFlag.GetComponent<PolygonCollider2D> ().enabled;
		bool KuF0 = kub0.GetComponent<CircleCollider2D> ().enabled;
		bool KuF1 = kub1.GetComponent<CircleCollider2D> ().enabled;
		bool KuF2 = kub2.GetComponent<CircleCollider2D> ().enabled;
		bool KuF3 = kub3.GetComponent<CircleCollider2D> ().enabled;

		if (PiF == true &&
		    KuF0 == true &&
		    KuF1 == true &&
		    KuF2 == true &&
		    KuF3 == true )
		/*if(Input.GetKey(KeyCode.A))*/
		{
			Check = true;
			ClearFlag.gameObject.SetActive (true);
			transform.position.Set (0, 0, 0);
		}
	}
}
