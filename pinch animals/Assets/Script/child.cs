using UnityEngine;
using System.Collections;

public class child : MonoBehaviour 
{

	void Start () 
	{
		transform.parent = GameObject.Find ("parent").transform;
	}

	void Update () 
	{
	
	}
}
