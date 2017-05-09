using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player3 : MonoBehaviour 
{
	public Vector2 SPEED = new Vector2(0.05f, 0.05f);
	public bool Check;
	bool poseFlag;

	SpriteRenderer MainSpriteRenderer;

	public GameObject playspr;
	public GameObject penchi;

	public Sprite NormalSprite;//待機状態

	public Slider _slider;
	public float Power;
	public static float PowerPre;
	float Speed; 

	public bool Press;
	public static bool PressPre;

	public GameObject obj=null;

	public Rigidbody2D rigid2D;

	public bool kubCheck;

	public int HitPoint;
	public bool Flag;

	public bool SeimeiFlag;



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
		kubInit();
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
		
	void kubInit()
	{
		kubCheck = false;
		Flag=false;
		SeimeiFlag = true;
		HitPoint = 3;
	}

	void kubUpdate ()
	{
		//抜けた後数値を初期化出来たら良し
		//数値が取れた後が問題で1回増減すると残りにも適用される
		//0にすると失敗の判定を取られるのも注意
		if (obj != null) 
		{
			//GameObject _child = obj.transform.FindChild ().gameObject;
			if (kubCheck == true && (PowerPre >= 0.5 && PowerPre <= 2.5)) 
			{
				kubCheck = false;
				//_child.GetComponent<CircleCollider2D> ().enabled = true;
				obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			
			}
		}
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

			kubUpdate ();

		/*	if (Input.GetKeyDown (KeyCode.Space)) 
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
		kubCheck = true;
		if (collider.gameObject.name == "kub") 
		{
			obj = collider.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		obj = null;
	}
}
