using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player2 : MonoBehaviour 
{
	public Vector2 SPEED = new Vector2(0.05f, 0.05f);
	public bool Check;
	bool poseFlag;

	public SpriteRenderer MainSpriteRenderer;
	public SpriteRenderer auraSprRend;

	public Sprite auraSpr1;
	public Sprite auraSpr2;
	public Sprite auraSpr3;

	public GameObject playspr;
	public GameObject penchi;

	public Sprite NormalSprite;//待機状態

	public Slider _slider;
	public Slider pullSlider;

	public GameObject sliderObj;
	public GameObject pullSliderObj;
	public float Power;
	public static float PowerPre;

	public float pullPower;

	float Speed;
	float pullSpeed;

	public GameObject obj=null;

	public Rigidbody2D rigid2D;

	public bool Flag;

	public bool pullFlag;

	public GameObject PlayerHP;

	public GameObject HP1;
	public GameObject HP2;
	public GameObject HP3;

	public int HitPoint;
	public static bool DeathFlag;

	AudioSource sound;

	public GameObject kubProper;
	public GameObject pilePropel;
	public GameObject polePropel;

	public GameObject aura;

	Vector3 vec;

	GameObject _child_pile;
	GameObject _child_pole;


	public enum State
	{
		Start,
		Interpose,
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

		//MainSpriteRenderer = playspr.GetComponent<SpriteRenderer>();
	
		Power = 0;
		PowerPre = 0;
		pullPower = 3;
		Speed = 0.3f;
		pullSpeed = 0.3f;
		rigid2D = GetComponent<Rigidbody2D>();//同じゲームオブジェクト貼られているリジッドボディへの参照（ポインタ）を取得
		//関数化をα終了後かβ終了後にする
		Flag=false;
		DeathFlag = false;
		pullFlag = false;
	}

	void Init()
	{
		Power = 0;
		Speed = 0.3f;
		state = State.Start;
		aura.SetActive (false);	
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
				_child_pile = obj.transform.FindChild ("pile_root").gameObject;
				if (Flag && (PowerPre > 0.0f && PowerPre < 4.3f)) 
				{
					//PlayerHP.SetActive (false);
					HitPointFunction ();
					Flag = false;
				}
				if (Flag && (PowerPre > 4.3f && PowerPre < 5.7f))
				{
					//_child_pile.GetComponent<PolygonCollider2D> ().enabled = true;
					//obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					Flag = false;
					pullFlag = true;
					//sound.PlayOneShot (sound.clip);
				}
				if (Flag && (PowerPre > 5.7f && PowerPre < 10)) 
				{
					obj.SetActive (false);
					HitPointFunction ();
					Flag = false;
				}
				if(pullFlag==true)
				{
					if (Input.GetKeyDown (KeyCode.Space)) 
					{
						pullPower += pullSpeed;
					}
					else 
					{
						pullPower -= 0.03f;
					}
					if (pullPower <= -1) 
					{
						pullFlag = false;
						HitPointFunction ();
					}
					if (pullPower >= 7) 
					{
						_child_pile.GetComponent<PolygonCollider2D> ().enabled = true;
						obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
						pullFlag = false;
					}
					pullSlider.value = pullPower;
				}
				break;

			case Type.pole:
				_child_pole = obj.transform.FindChild ("pole_root").gameObject;
				if (Flag && (PowerPre >0.0f && PowerPre < 7.0f))
				{
					//PlayerHP.SetActive (false);
					HitPointFunction();
					Flag = false;
				}
				if (Flag && (PowerPre > 7.0f && PowerPre < 8.0f))
				{
					//_child_pole.GetComponent<BoxCollider2D> ().enabled = true;
					//obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					Flag = false;
					pullFlag = true;
					//sound.PlayOneShot (sound.clip);

				}
				if (Flag && (PowerPre > 8.5f && PowerPre < 10))
				{
					obj.SetActive (false);
					HitPointFunction();
					Flag = false;
				}
				if(pullFlag==true)
				{
					if (Input.GetKeyDown (KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow)) 
					{
						pullPower += pullSpeed;
					}
					if (pullPower <= -1) 
					{
						pullFlag = false;
					}
					if (pullPower >= 5) 
					{
						_child_pole.GetComponent<BoxCollider2D> ().enabled = true;
						obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
						pullFlag = false;
					}
					pullSlider.value = pullPower;
				}
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

		HitPoint = PlayerHP.transform.childCount;

		if (poseFlag == false) 
		{
			if (obj != null) 
			{
				switch (state)
				{
				case State.Start:
					if (pullFlag != true) 
					{
						if (Input.GetKeyDown (KeyCode.Space)) 
						{
							state = State.Interpose;
						}
					}
					break;
				case State.Interpose:
					aura.SetActive (true);
					if (Power >= 10) {
						Speed *= -1;
					}

					if (Power <= -1) {
						Speed *= -1;
					}
					if (Power >= 0f && Power <= 3.0f) 
					{						
						auraSprRend.sprite = auraSpr1;

					}
					if (Power >= 3.1f && Power <= 7.0f) 
					{						
						auraSprRend.sprite = auraSpr2;
					}
					if (Power >= 7.1f && Power <= 10f) 
					{						
						auraSprRend.sprite = auraSpr3;
					}

					auraSprRend.color=Color.Lerp (Color.white, Color.red, (Power / 10));
					vec.Set ((Power+1)/5,(Power+1)/5,(Power+1)/5);
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

			if (pullFlag == false)
			{
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
			}

			kubUpdate ();

			transform.position = Position;
			transform.eulerAngles = Rotation;
			aura.transform.localScale = vec;
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
			polePropel.SetActive (true);
			type = Type.pole;
		}
		if (obj != null) 
		{
			sliderObj.SetActive (true);
			pullSliderObj.SetActive (true);
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
		if (polePropel.activeInHierarchy == true) 
		{
			polePropel.SetActive (false);
		}
		if (sliderObj.activeInHierarchy == true) 
		{
			sliderObj.SetActive (false);
		}
		if (pullSliderObj.activeInHierarchy == true) 
		{
			pullSliderObj.SetActive (false);
		}
	}
}