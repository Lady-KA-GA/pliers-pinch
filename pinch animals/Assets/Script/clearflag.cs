using UnityEngine;
using System.Collections;

public class clearflag : MonoBehaviour 
{
	public GameObject Flag1;
	public GameObject Flag2;
	public GameObject Flag3;
	public GameObject Flag4;

	public GameObject ClearFlag;

	public static bool Check;

	void Start ()
	{
		Check = false;
	}


	void Update ()
	{	
		bool flag1 = Flag1.GetComponent<CircleCollider2D> ().enabled;
		bool flag2 = Flag2.GetComponent<CircleCollider2D> ().enabled;
		bool flag3 = Flag3.GetComponent<CircleCollider2D> ().enabled;
		bool flag4 = Flag4.GetComponent<CircleCollider2D> ().enabled;


		if (flag1 == true && flag2 == true && flag3 == true && flag4 == true) 
		{
			Check = true;
			ClearFlag.gameObject.SetActive (true);
		}
	}
}
