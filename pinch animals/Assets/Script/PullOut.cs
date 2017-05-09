using UnityEngine;
using System.Collections;

public class PullOut : MonoBehaviour 
{
	public GameObject Kub;
	public GameObject Pile;

	public bool kubflag;

	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		kubflag = Kub.GetComponent<CircleCollider2D> ().enabled;

		if (kubflag == true) 
		{
			AudioManager.Instance.PlaySE ("oneup");
		}

	}
}
