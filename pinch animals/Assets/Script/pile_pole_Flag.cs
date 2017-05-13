using UnityEngine;
using System.Collections;

public class pile_pole_Flag : MonoBehaviour 
{
	public GameObject pile0;
	public GameObject pile1;
	public GameObject pile2;
	public GameObject pile3;

	public GameObject poleFlag;

	public GameObject ClearFlag;

	public static bool clearCheck;

	void Start ()
	{
		clearCheck = false;
	}


	void Update ()
	{
		bool PoF = poleFlag.GetComponent<BoxCollider2D> ().enabled;
		bool PiF0 = pile0.GetComponent<PolygonCollider2D> ().enabled;
		bool PiF1 = pile1.GetComponent<PolygonCollider2D> ().enabled;
		bool PiF2 = pile2.GetComponent<PolygonCollider2D> ().enabled;
		bool PiF3 = pile3.GetComponent<PolygonCollider2D> ().enabled;

		if (PoF == true &&
			PiF0 == true &&
			PiF1 == true &&
			PiF2 == true &&
			PiF3 == true )
			/*if(Input.GetKey(KeyCode.A))*/
		{
			clearCheck = true;
			ClearFlag.gameObject.SetActive (true);
			transform.position.Set (0, 0, 0);
		}
	}
}
