using UnityEngine;
using System.Collections;

public class Player1: MonoBehaviour 
{   	// 速度
	public Vector2 SPEED = new Vector2(0.05f, 0.05f);
	public int r = 0;	
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// 移動処理
		Move();
		Rota();
	}

	// 移動関数
	void Move(){
		// 現在位置をPositionに代入
		Vector2 Position = transform.position;
		// 左キーを押し続けていたら
		if(Input.GetKey("a")){
			// 代入したPositionに対して加算減算を行う
			Position.x -= SPEED.x;
		}
		if(Input.GetKey("d")){ // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.x += SPEED.x;
		}
		if(Input.GetKey("w")){ // 上キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.y += SPEED.y;
		}
		if(Input.GetKey("s")){ // 下キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.y -= SPEED.y;
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
	}

	void Rota()
	{
		if(Input.GetKey("b"))
		{
			r++;

		}
		transform.Rotate (new Vector3 (0, 0, r));	
	}
}
