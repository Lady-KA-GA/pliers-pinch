using UnityEngine;
using System.Collections;

public class clearflag_3 : MonoBehaviour 
{
	public GameObject poleFlag1;
	public GameObject poleFlag2;
	public GameObject poleFlag3;
	public GameObject poleFlag4;

	public GameObject ClearFlag;

	public static bool Check;

	void Start ()
	{
		Check = false;
	}


	void Update ()
	{	
		bool PoF1 = poleFlag1.GetComponent<BoxCollider2D> ().enabled;
		bool PoF2 = poleFlag2.GetComponent<BoxCollider2D> ().enabled;
		bool PoF3 = poleFlag3.GetComponent<BoxCollider2D> ().enabled;
		bool PoF4 = poleFlag4.GetComponent<BoxCollider2D> ().enabled;



		if (PoF1 == true && PoF2 == true && PoF3 == true && PoF4 == true)
		{
			Check = true;
			ClearFlag.gameObject.SetActive (true);
		}
	}
}
