using UnityEngine;
using System.Collections;

public class testMoveManerger : MonoBehaviour 
{
	GameObject BlockCenter;
	GameObject BlockLeft;
	GameObject BlockRight;
	public float speed = 5;
	void Start () 
	{
		BlockCenter=GameObject.Find("blockoya");
	}
	
	// Update is called once per frame
	void Update () 
	{
		float x = 0.0f;

		// 上・下
		float y = 0.1f;
		// 移動する向きを求める
		Vector2 direction = new Vector2 (x, y).normalized;

	}
}
