using UnityEngine;
using System.Collections;

public class clear : MonoBehaviour 
{
	public GameObject poleFlag;
	public GameObject kubFlag;
	public GameObject pileFlag;
	public GameObject clearF;

	void Start ()
	{
		
	}


	void Update ()
	{
		bool PoF = poleFlag.GetComponent<BoxCollider2D> ().enabled;
		bool PiF = pileFlag.GetComponent<PolygonCollider2D> ().enabled;
		bool KuF = kubFlag.GetComponent<CircleCollider2D> ().enabled;
	
		if (PoF == true && PiF == true && KuF == true) 
		{
			clearF.SetActive (true);
		}
	}
}
