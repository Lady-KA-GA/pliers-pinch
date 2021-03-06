﻿using UnityEngine;
using System.Collections;

public class kub : MonoBehaviour 
{
	public GameObject kub_body;
	public GameObject kub_root;
	public bool Check;

	public float HP;
	public int HitPoint;
	public bool Flag;

	public bool SeimeiFlag;

	private AudioSource nuku_se;//抜く時になるSE
	public int Count;

	void Start () 
	{
		Check = false;
		Flag=false;
		SeimeiFlag = true;
		HitPoint = 3;
		Count = 0;
		nuku_se = GetComponent<AudioSource>();
	}
		
	void Init()
	{
		Check = false;
		Flag=false;
		SeimeiFlag = true;
		HitPoint = 3;
	}

	void Update ()
	{
		//抜けた後数値を初期化出来たら良し
		//数値が取れた後が問題で1回増減すると残りにも適用される
		//0にすると失敗の判定を取られるのも注意
		HP = Player3.PowerPre;
		if (Check == true &&/* Flag == true &&*/ (HP >= 0.5 && HP <= 2.5)) 
		{
			Check = false;
			kub_root.GetComponent<CircleCollider2D> ().enabled = true;
			kub_body.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;

			if (Count == 0)
			{
				Count += 1;	
			}

		}

		if (Count == 1)
		{
			Debug.Log("a");
			nuku_se.PlayOneShot(nuku_se.clip);

			Count += 1;
		}

	/*		if (HitPoint != 0) 
			{
				if (Check == true && Flag == true &&(HP <= 0.4 || HP >= 2.6)) 
				{
					HitPoint -= 1;
				}
			} 
			else
			{
				SeimeiFlag = false;
			}

		if(SeimeiFlag == false)
		{
			gameObject.SetActive (false);
		}
*/
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
