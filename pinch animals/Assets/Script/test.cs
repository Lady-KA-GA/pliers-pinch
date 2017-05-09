using UnityEngine;
using System.Collections;

public class test : MonoBehaviour 
{    
	// 移動スピード
	//public float speed = 5;

	//void Update ()
	//{
		// 右・左
	//	float x = Input.GetAxisRaw ("Horizontal");

		// 上・下
	//	float y = Input.GetAxisRaw ("Vertical");

		// 移動する向きを求める
	//	Vector2 direction = new Vector2 (x, y).normalized;

		// 移動する向きとスピードを代入する
	//	GetComponent<Rigidbody2D>().velocity = direction * speed;
	//}


	//void Start () 
	//{
		
	//}

	//void Update () 
	//{
	//	if (Input.GetKey ("up")) 
	//	{
	//		transform.position += transform.right * 0.01f;
	//	}
	//	if (Input.GetKey("right")) 
	//	{
	//		transform.Rotate(0, 10, 0);
	//	}
	//	if (Input.GetKey ("left")) 
	//	{
	//		transform.Rotate(0, -10, 0);
	//	}
	//}

	public GameObject Player;
	int horizon;
	int vertical;
	public bool characterInQuicksand = false;

	void Start () 
	{
		//Player1 = GameObject.Find ("Player1");
	
	}

	void Update ()
	{
//		Flag = Player1.GetComponent<CharacterController> ().isGrounded;
		if (Input.GetKey ("right")) {
			horizon = 5;
			//Player1.GetComponent<RigidBody2D> ().velocity = new Vector3(horizon, Player1.GetComponent<RigidBody2D>().velocity.y, 0);
			Player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (horizon, Player.GetComponent<Rigidbody2D> ().velocity.y);
		} else if (Input.GetKey ("left")) {
			horizon = 5;
			//Player1.GetComponent<RigidBody2D> ().velocity = new Vector3(-horizon, Player1.GetComponent<RigidBody2D>().velocity.y, 0);
			Player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-horizon, Player.GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (characterInQuicksand) 
		{
			if (Input.GetKey ("up")) 
			{
				vertical = 5;
				//Player1.GetComponent<RigidBody2D> ().velocity = new Vector3 (Player1.GetComponent<RigidBody2D> ().velocity.x, vertical, 0);
				Player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Player.GetComponent<Rigidbody2D> ().velocity.x, vertical);
				characterInQuicksand = false;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		characterInQuicksand = true;
	}
}
