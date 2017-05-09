using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player24 : MonoBehaviour 
{
	public Vector2 SPEED = new Vector2(0.05f, 0.05f);
	public bool Check;
	bool poseFlag;

	SpriteRenderer MainSpriteRenderer;

	public GameObject playspr;
	public GameObject penchi;

	public Sprite NormalSprite;//待機状態
	public Sprite WalkSprite1;//歩く状態1
	public Sprite WalkSprite2;//歩く状態2
	public Sprite InterposeSprite;//挟む状態
	public Sprite PulloutSprite;//抜く状態

	public Slider _slider;
	public float Power;
	public static float PowerPre;
	float Speed; 

	public bool Press;
	public static bool PressPre;

	GameObject obj=null;


	public Rigidbody2D rigid2D;

	public enum State
	{
		Start,
		Fluctuation,
		Stop,
		Initializ
	};

	public static State state;

	void Start () 
	{
		Check = false;

		MainSpriteRenderer = playspr.GetComponent<SpriteRenderer>();

		Power = 0;
		PowerPre = 0;
		Speed = 0.1f;

		Press = false;
		PressPre = false;
		rigid2D = GetComponent<Rigidbody2D>();//同じゲームオブジェクトい貼られているリジッドボディへの参照（ポインタ）を取得
		//関数化をα終了後かβ終了後にする

	}

	void Init()
	{
		Power = 0;
		//PowerPre = 0;
		//Speed = 0.0f;
		Speed = 0.1f;

		Press = false;
		PressPre = false;
	}


	void Update () 
	{
		poseFlag = Pose.i;
		Vector2 Position = transform.position;
		Vector2 Rotation = transform.eulerAngles;

		Vector2 PenPos = new Vector2 (penchi.transform.position.x+0.3f, penchi.transform.position.y);

		switch (state) 
		{
		case State.Start:
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				state = State.Fluctuation;
			}
			break;
		case State.Fluctuation:
			if (Power >= 10) 
			{
				Speed *= -1;
			}

			if (Power <= -1) 
			{
				Init ();
			}

			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				state = State.Stop;
			}
			Power += Speed;
			_slider.value = Power;
			break;
		case State.Stop:
			PowerPre = Power;
			state = State.Initializ;
			break;
		case State.Initializ:
			if (Power != 0) 
			{
				Init ();
			}
			else 
			{
				state = State.Start;
			}
			break;
		default:
			break;
		}


		if (poseFlag == false) 
		{
			//MainSpriteRenderer.sprite = PulloutSprite;
			if (Input.GetKey (KeyCode.LeftArrow)) 
			{
				Rotation.y = 0;
				Position.x -= SPEED.x;
			}

			if (Input.GetKey (KeyCode.RightArrow)) 
			{
				Rotation.y = 180;
				Position.x += SPEED.x;
			}
			if (Check == true)
			{
				
				if (Input.GetKeyDown (KeyCode.UpArrow)) 
				{
					Position.y += SPEED.y + 2;
					Check = false;

				/*	Vector2 velo = rigid2D.velocity;
					Vector2 newVelo = new Vector2 (velo.x,20);
					velo = newVelo;*/
				}
			}

	/*		if (Input.GetKeyDown (KeyCode.Space)) 
			{
				if (Press == false) 
				{
					Press = true;
					PressPre = false;
				}
				else 
				{
					PowerPre = Power;
					Press = false;
					PressPre = true;
				}
			}

			if (Press == true)
			{
				if (Power >= 10) 
				{
					Speed*=-1;
				}
				Power += Speed;
				if (Power <= -1) 
				{
					Init ();
				}
			} 
			else 
			{
				Init ();
			}
*/
			transform.position = Position;
			transform.eulerAngles = Rotation;
		}
		else 
		{

		}

		//_slider.value = Power;
	}

	/// <summary>
	///関数の説明
	/// </summary>
	/// <param name="collider">Collider.変数とか？</param>
	void OnTriggerStay2D(Collider2D collider)
	{
		Check = true;
		if (collider.gameObject.name == "kub") 
		{
			obj = collider.gameObject;
		}
	}
}
