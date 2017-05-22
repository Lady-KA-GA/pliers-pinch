using UnityEngine;
using System.Collections;

public class clearflag_2 : MonoBehaviour 
{
	public GameObject poleFlag;
	public GameObject swordFlag;
	public GameObject pileFlag;

	public GameObject ClearFlag;

	public static bool Check;

	void Start ()
	{
		Check = false;
	}


	void Update ()
	{	
		bool SwF = swordFlag.GetComponent<PolygonCollider2D> ().enabled;
		bool PiF = pileFlag.GetComponent<PolygonCollider2D> ().enabled;
		bool PoF = poleFlag.GetComponent<BoxCollider2D> ().enabled;



		if (PoF == true && PiF == true && SwF == true) 
		{
			Check = true;
			ClearFlag.gameObject.SetActive (true);
		}
	}
}
