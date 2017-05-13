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
	public GameObject sliderObj;
	public float Power;
	public static float PowerPre;
	float Speed; 

	public GameObject obj=null;

	public Rigidbody2D rigid2D;

	public bool Flag;

	public GameObject PlayerHP;

	public GameObject HP1;
	public GameObject HP2;
	public GameObject HP3;

	public int HitPoint;
	public static bool DeathFlag;

	AudioSource sound;

	public GameObject kubProper;
	public GameObject pilePropel;

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
		Speed = 0.3f;
		rigid2D = GetComponent<Rigidbody2D>();//同じゲームオブジェクトい貼られているリジッドボディへの参照（ポインタ）を取得
		//関数化をα終了後かβ終了後にする
		Flag=false;
		DeathFlag = false;
	}

	void Init()
	{
		Power = 0;
		Speed = 0.3f;
		state = State.Start;
	}

	void kubUpdate ()
	{
		//抜けた後数値を初期化出来たら良し
		//数値が取れた後が問題で1回増減すると残りにも適用される
		//0にすると失敗の判定を取られるのも注意
		if (obj != null)
		{
			sound = obj.GetComponent<AudioSource> ();
			switch (type)
			{
			case Type.kub:
				GameObject _child_kub = obj.transform.FindChild ("kub_root").gameObject;
				if (Flag && (PowerPre >0.0f && PowerPre < 1.5f))
				{
					//PlayerHP.SetActive (false);
					HitPointFunction();
					Flag = false;
				}
				if (Flag && (PowerPre > 1.5f && PowerPre < 3.0f))
				{
					_child_kub.GetComponent<CircleCollider2D> ().enabled = true;
					obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					Flag = false;
					sound.PlayOneShot (sound.clip);

				}
				if (Flag && (PowerPre > 3.0f && PowerPre < 10))
				{
					obj.SetActive (false);
					HitPointFunction();
					Flag = false;
				}
				break;

			case Type.pile:
				GameObject _child_pile = obj.transform.FindChild ("pile_root").gameObject;
				if (Flag && (PowerPre >0.0f && PowerPre < 4.0f))
				{
					//PlayerHP.SetActive (false);
					HitPointFunction();
					Flag = false;
				}
				if (Flag && (PowerPre > 4.3f && PowerPre < 5.7f))
				{
					_child_pile.GetComponent<PolygonCollider2D> ().enabled = true;
					obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					Flag = false;
					sound.PlayOneShot (sound.clip);

				}
				if (Flag && (PowerPre > 5.0f && PowerPre < 10))
				{
					obj.SetActive (false);
					HitPointFunction();
					Flag = false;
				}
				break;

			case Type.pole:
				GameObject _child_pole = obj.transform.FindChild ("pole_root").gameObject;
				if (Flag && (PowerPre >0.0f && PowerPre < 7.0f))
				{
					//PlayerHP.SetActive (false);
					HitPointFunction();
					Flag = false;
				}
				if (Flag && (PowerPre > 7.0f && PowerPre < 8.0f))
				{
					_child_pole.GetComponent<BoxCollider2D> ().enabled = true;
					obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					Flag = false;
					sound.PlayOneShot (sound.clip);

				}
				if (Flag && (PowerPre > 8.5f && PowerPre < 10))
				{
					obj.SetActive (false);
					HitPointFunction();
					Flag = false;
				}
				break;
			default:
				break;
			}
		}
	}
	void Update ()
	{
		//sound = obj.GetComponent<AudioSource> ();

		poseFlag = Pose.i;
		Vector2 Position = transform.position;
		Vector2 Rotation = transform.eulerAngles;

		HitPoint = PlayerHP.transform.childCount;

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

	void HitPointFunction()
	{
		switch(HitPoint)
		{
		case 1:
			DeathFlag = true;
			Destroy (HP1);
			break;
		case 2:
			Destroy (HP2);
			break;
		case 3:
			Destroy (HP3);
			break;
		default:
			break;
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
			kubProper.SetActive (true);
			type = Type.kub;
		}
		if (collider.gameObject.name == "pile")
		{
			obj = collider.gameObject;
			pilePropel.SetActive (true);
			type = Type.pile;
		}
		if (collider.gameObject.name == "pole") 
		{
			obj = collider.gameObject;
			//polePropel.SetActive (true);
			type = Type.pole;
		}
		if (obj != null) 
		{
			sliderObj.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		Check = false;
		obj = null;

		if (kubProper.activeInHierarchy == true) 
		{
			kubProper.SetActive (false);
		}
		if (pilePropel.activeInHierarchy == true) 
		{
			pilePropel.SetActive (false);
		}
	/*	if (PolePropel.activeInHierarchy == true) 
		{
			PolePropel.SetActive (false);
		}*/
		if (sliderObj.activeInHierarchy == true) 
		{
			sliderObj.SetActive (false);
		}
	}
}