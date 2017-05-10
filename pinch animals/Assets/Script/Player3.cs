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

	public GameObject obj=null;

	public Rigidbody2D rigid2D;

	public bool Flag;

	public GameObject PlayerHP;

	public enum State
	{
		Start,
		Fluctuation,
		Initializ
	};

	public enum Type
	{
		kub,
		pile,
		pole
	};

	public State state;
	public Type type;

	void Start () 
	{
		Check = false;

		MainSpriteRenderer = playspr.GetComponent<SpriteRenderer>();

		Power = 0;
		PowerPre = 0;
		Speed = 0.1f;
		rigid2D = GetComponent<Rigidbody2D>();//同じゲームオブジェクトい貼られているリジッドボディへの参照（ポインタ）を取得
		//関数化をα終了後かβ終了後にする
		Flag=false;
	}

	void Init()
	{
		Power = 0;
		Speed = 0.1f;
		state = State.Start;
	}

	void kubUpdate ()
	{
		//抜けた後数値を初期化出来たら良し
		//数値が取れた後が問題で1回増減すると残りにも適用される
		//0にすると失敗の判定を取られるのも注意
		if (obj != null)
		{
			switch (type)
			{
			case Type.kub:
				GameObject _child_kub = obj.transform.FindChild ("kub_root").gameObject;
				if (Flag && (PowerPre >0.0f && PowerPre < 1.5f))
				{
					PlayerHP.SetActive (false);
					Flag = false;
				}
				if (Flag && (PowerPre > 1.5f && PowerPre < 3.0f))
				{
					_child_kub.GetComponent<CircleCollider2D> ().enabled = true;
					obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					Flag = false;

				}
				if (Flag && (PowerPre > 3.0f && PowerPre < 11))
				{
					obj.SetActive (false);
					Flag = false;
				}
				break;

			case Type.pile:
				GameObject _child_pile = obj.transform.FindChild ("pile_root").gameObject;
				if (Flag && (PowerPre >0.0f && PowerPre < 4.0f))
				{
					PlayerHP.SetActive (false);
					Flag = false;
				}
				if (Flag && (PowerPre > 4.0f && PowerPre < 5.0f))
				{
					_child_pile.GetComponent<PolygonCollider2D> ().enabled = true;
					obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					Flag = false;

				}
				if (Flag && (PowerPre > 5.0f && PowerPre < 11))
				{
					obj.SetActive (false);
					Flag = false;
				}
				break;

			case Type.pole:

				break;
			default:
				break;
			}
		}
	}
	void Update ()
	{
		poseFlag = Pose.i;
		Vector2 Position = transform.position;
		Vector2 Rotation = transform.eulerAngles;

		//Vector2 PenPos = new Vector2 (penchi.transform.position.x+0.3f, penchi.transform.position.y);
		if (poseFlag == false) 
		{
			if (obj != null) 
			{
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
						PowerPre = Power;
						Flag = true;
						state = State.Initializ;
					}
					Power += Speed;
					_slider.value = Power;
					break;
				case State.Initializ:

					Init ();
			
					break;
				default:
					break;
				}
			}
			//MainSpriteRenderer.sprite = PulloutSprite;
			if (Input.GetKey (KeyCode.LeftArrow)) 
			{
				Rotation.y = 0;
				Position.x -= SPEED.x;
				state = State.Initializ;
			}

			if (Input.GetKey (KeyCode.RightArrow)) 
			{
				Rotation.y = 180;
				Position.x += SPEED.x;
				state = State.Initializ;
			}
			if (Check == true) 
			{
				if (Input.GetKeyDown (KeyCode.UpArrow)) 
				{
					Position.y += SPEED.y + 2;
					Check = false;
					state = State.Initializ;

					/*	Vector2 velo = rigid2D.velocity;
					Vector2 newVelo = new Vector2 (velo.x,20);
					velo = newVelo;*/
				}
			}

			kubUpdate ();

			transform.position = Position;
			transform.eulerAngles = Rotation;
		}
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
			type = Type.kub;
		}
		if (collider.gameObject.name == "pile") 
		{
			obj = collider.gameObject;
			type = Type.pile;
		}
		if (collider.gameObject.name == "pole") 
		{
			type = Type.pole;
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		Check = false;
		obj = null;
	}
}