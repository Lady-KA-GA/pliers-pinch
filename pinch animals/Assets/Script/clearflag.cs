using UnityEngine;
using System.Collections;

public class clearflag : MonoBehaviour 
{
	public GameObject poleFlag;
	public GameObject kubFlag;
	public GameObject pileFlag;

	public GameObject ClearFlag;

	public static bool Check;

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
			Check = true;
			ClearFlag.gameObject.SetActive (true);
		}
	}
}
