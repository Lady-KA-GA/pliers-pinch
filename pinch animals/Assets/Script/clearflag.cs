using UnityEngine;
using System.Collections;

public class clearflag : MonoBehaviour 
{
	public GameObject Flag1;
	public GameObject Flag2;
	public GameObject Flag3;
	public GameObject Flag4;
	public GameObject Flag5;
	public GameObject Flag6;
	public GameObject Flag7;
	public GameObject Flag8;
	public GameObject Flag9;
	public GameObject Flag10;
	public GameObject Flag11;
	public GameObject Flag12;
	public GameObject Flag13;
	public GameObject Flag14;
	public GameObject Flag15;
	public GameObject Flag16;
	public GameObject Flag17;
	public GameObject Flag18;

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
		bool flag5 = Flag5.GetComponent<CircleCollider2D> ().enabled;
		bool flag6 = Flag6.GetComponent<CircleCollider2D> ().enabled;
		bool flag7 = Flag7.GetComponent<CircleCollider2D> ().enabled;
		bool flag8 = Flag8.GetComponent<CircleCollider2D> ().enabled;
		bool flag9 = Flag9.GetComponent<CircleCollider2D> ().enabled;
		bool flag10 = Flag10.GetComponent<CircleCollider2D> ().enabled;
		bool flag11 = Flag11.GetComponent<CircleCollider2D> ().enabled;
		bool flag12 = Flag12.GetComponent<CircleCollider2D> ().enabled;
		bool flag13 = Flag13.GetComponent<CircleCollider2D> ().enabled;
		bool flag14 = Flag14.GetComponent<CircleCollider2D> ().enabled;
		bool flag15 = Flag15.GetComponent<CircleCollider2D> ().enabled;
		bool flag16 = Flag16.GetComponent<CircleCollider2D> ().enabled;
		bool flag17 = Flag17.GetComponent<CircleCollider2D> ().enabled;
		bool flag18 = Flag18.GetComponent<CircleCollider2D> ().enabled;


		if (flag1 == true && flag2 == true && flag3 == true && flag4 == true &&
			flag5 == true && flag6 == true && flag7 == true && flag8 == true &&
			flag9 == true && flag10 == true && flag11 == true && flag12 == true &&
			flag13 == true && flag14 == true && flag15 == true && flag16 == true &&
			flag17 == true && flag18 == true) 
		{
			Check = true;
			ClearFlag.gameObject.SetActive (true);
		}
	}
}
