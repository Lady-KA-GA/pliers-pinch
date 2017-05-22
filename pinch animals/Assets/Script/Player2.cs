using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player2 : MonoBehaviour 
{
	Vector2 SPEED;//プレイヤーの移動速度
	bool Check;//プレイヤーの接地フラグ
	bool poseFlag;//ポーズ中かどうかのフラグ

	public SpriteRenderer MainSpriteRenderer;//プレイヤーのスプライトレンダラー
	public SpriteRenderer auraSprRend;//オーラのスプライトレンダラー

	public Sprite auraSpr1;//オーラの差分１
	public Sprite auraSpr2;//オーラの差分２
	public Sprite auraSpr3;//オーラの差分３

	public GameObject playspr;//プレイヤーのスプライトが入ってるゲームオブジェクト
	public GameObject penchi;//ペンチのゲームオブジェクト

	public Sprite pinch1;
	public Sprite pinch2;

	public Sprite walk;

	public Sprite nuki;



	public Sprite NormalSprite;//待機状態の画像

	public Slider _slider;
	public Slider pullSlider;

	public GameObject sliderObj;
	public GameObject pullSliderObj;
	float Power;
	public float PowerPre;

	public float pullPower;
	public float PullTime;

	float Speed;
	float pullSpeed;

	int Count;

	float CoolTime;

	GameObject obj;

	public Rigidbody2D rigid2D;

	public bool Flag;

	public bool pullFlag;

	public GameObject HP1;
	public GameObject HP2;
	public GameObject HP3;

	int HitPoint;
	public static bool DeathFlag;

	AudioSource sound;

	public GameObject kubProper;
	public GameObject pilePropel;
	public GameObject polePropel;
	public GameObject pile_pull_Proper;

	public GameObject aura;

	public GameObject Numbel;

	Vector3 vec;

	GameObject ObjChild;
	GameObject PosObj;

	GameObject ObjPre;

	int horizon;
	int vertical;


	float RoZ;

	float RoSpeed;

	bool JudgeF;

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

		SPEED = new Vector2(0.05f, 0.05f);//プレイヤーの移動速度
		Check = false;

		Power = 0;
		PowerPre = 0;
		pullPower = 0;
		//Speed = 0.3f;
		pullSpeed = 1.2f;
		rigid2D = GetComponent<Rigidbody2D>();//同じゲームオブジェクト貼られているリジッドボディへの参照（ポインタ）を取得
		//関数化をα終了後かβ終了後にする
		Flag=false;
		DeathFlag = false;
		pullFlag = false;
		PullTime = 0;

		Count = 0;

		obj = null;

		HitPoint = 3;

		ObjChild = null;

		RoZ = 0;

		PosObj = GameObject.Find ("pos");

		RoSpeed = 1;

		JudgeF = false;

		CoolTime = 0.0f;
	}

	void ObjInit()
	{
		obj = null;
		ObjChild = null;
	}

	void ObstacleUpdate ()
	{
		if (obj != null)
		{
			ObjChild = obj.transform.FindChild ("root").gameObject;
			switch (type) 
			{
			case Type.kub:

				if (Flag && (PowerPre >= 0.0f && PowerPre <= 1.4f)) {
					HitPointFunction ();
					Flag = false;
				}
				if (Flag && (PowerPre >= 1.5f && PowerPre <= 3.0f)) 
				{
					vertical = 20;
					ObjChild.GetComponent<CircleCollider2D> ().enabled = true;
					obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					obj.GetComponent<Rigidbody2D> ().angularVelocity = 1000.0f;
					obj.GetComponent<Rigidbody2D> ().velocity = new Vector3 (obj.GetComponent<Rigidbody2D> ().velocity.x, vertical, 0);
					Flag = false;
					//sound.PlayOneShot (sound.clip);
				}
				if (Flag && (PowerPre >= 3.1f && PowerPre <= 10)) {
					//obj.SetActive (false);
					HitPointFunction ();
					Flag = false;
				}
				JudgeF = ObjChild.GetComponent<CircleCollider2D> ().enabled;

				break;

			case Type.pile:

				//クールタイム
				//時間を表示してカウントダウン。
				//カウントダウン後、パワコンゲージを開始
				//連打まで「0」　という表示
				//連打まで　の表示を何にするか思考

				if (Flag && (PowerPre >= 0.0f && PowerPre <= 4.2f)) 
				{
					//PlayerHP.SetActive (false);
					HitPointFunction ();
					Flag = false;
				}
				if (Flag && (PowerPre >= 4.3f && PowerPre <= 5.7f)) 
				{
					Flag = false;
					pullFlag = true;
					pullPower = 5;
					//sound.PlayOneShot (sound.clip);
				}
				if (Flag && (PowerPre >= 5.8f && PowerPre <= 10)) 
				{
					HitPointFunction ();
					Flag = false;
				}


				if (pullFlag == true) 
				{
					Numbel.SetActive (true);
					if (Input.GetKeyDown (KeyCode.Space)) 
					{
						pullPower += pullSpeed;
					} 
					else 
					{
						pullPower -= 0.08f;
					}

					if (pullPower <= 2.9f)
					{
						pullFlag = false;
						HitPointFunction ();
						pullPower = 5;
					}
					if (pullPower >= 7.1f) 
					{
						pullFlag = false;
						HitPointFunction ();
						pullPower = 5;
					}

					if (pullPower >= 3.0f && pullPower <= 7.0f) 
					{
						PullTime += Time.deltaTime;
					}

					if (PullTime >= 3) 
					{
						vertical = 20;
						horizon = -5;
						PullTime = 0;
						pullPower = 5;
						obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
						ObjChild.GetComponent<PolygonCollider2D> ().enabled = true;
						obj.GetComponent<Rigidbody2D> ().velocity = new Vector3 (horizon, vertical, 0);
						obj.GetComponent<Rigidbody2D> ().angularVelocity = 1000.0f;

						pullFlag = false;
						Numbel.SetActive (false);
					}
					pullSlider.value = pullPower;
				}

				JudgeF = ObjChild.GetComponent<PolygonCollider2D> ().enabled;

				PowerPre = 0;
				break;

			case Type.pole:
				if (Flag && (PowerPre >= 0.0f && PowerPre <= 7.1f)) 
				{
					//PlayerHP.SetActive (false);
					HitPointFunction ();
					Flag = false;
				}

				if (Flag && (PowerPre >= 7.0f && PowerPre <= 8.5f)) 
				{
					Flag = false;
					pullFlag = true;
					pullPower = 0;
					Count = 0;

					obj.GetComponent<EdgeCollider2D> ().enabled = true;

					//sound.PlayOneShot (sound.clip);

				}

				if (Flag && (PowerPre >= 8.6f && PowerPre <= 10)) 
				{
					HitPointFunction ();
					Flag = false;
				}
					
				if (pullFlag == true) 
				{
					int Ang0 = 7;
					int Ang1 = 13;
					int Ang2 = 19;
					int Ang3 = 24;

					switch (Count) 
					{
					case 0:
						if (RoZ >= Ang0)
						{
							RoSpeed *= -1;
						}
						if (RoZ <= Ang0 * -1) 
						{
							RoSpeed *= -1;
						}

						if (RoZ >= -5 && RoZ <= 5)
						{
							if (Input.GetKeyDown (KeyCode.Space)) 
							{
								Count = 1;
								pullPower += 2;
							}
						}

						break;

					case 1:
						if (RoZ >= Ang1) 
						{
							RoSpeed *= -1;
						}
						if (RoZ <= Ang1 * -1) 
						{
							RoSpeed *= -1;
						}

						if (RoZ >= -3 && RoZ <= 3) 
						{
							if (Input.GetKeyDown (KeyCode.Space)) 
							{
								Count = 2;
								pullPower += 2;
							}
						}
						break;

					case 2:
						if (RoZ >= Ang2) 
						{
							RoSpeed *= -1;
						}
						if (RoZ <= Ang2 * -1) 
						{
							RoSpeed *= -1;
						}

						if (RoZ >= -1 && RoZ <= 1) 
						{
							if (Input.GetKeyDown (KeyCode.Space)) 
							{
								Count = 3;
								pullPower += 3;
							}
						}
						break;
					case 3:
						if (RoZ >= Ang3) 
						{
							RoSpeed *= -1;
						}
						if (RoZ <= Ang3 * -1) 
						{
							RoSpeed *= -1;
						}

						if (RoZ >= -1 && RoZ <= 1) 
						{
							if (Input.GetKeyDown (KeyCode.Space)) 
							{
								Count = 3;
								pullPower += 3;
							}
						}
						break;
					default:
						break;
					}


					if (pullPower >= 8.0f) 
					{
						vertical = 20;
						obj.GetComponent<Rigidbody2D> ().velocity = new Vector3 (obj.GetComponent<Rigidbody2D> ().velocity.x, vertical, 0);
						ObjChild.GetComponent<BoxCollider2D> ().enabled = true;
						ObjChild.GetComponent<CircleCollider2D> ().enabled = true;
						obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
						obj.GetComponent<Rigidbody2D> ().angularVelocity = 1000.0f;
						pullFlag = false;
					}
					RoZ += RoSpeed;

					Vector3 RVec = new Vector3 (0.0f, 0.0f, RoZ);

					PosObj.transform.eulerAngles = RVec;

				}
				JudgeF = ObjChild.GetComponent<BoxCollider2D> ().enabled;
				PowerPre = 0;
				pullSlider.value = pullPower;
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
							MainSpriteRenderer.sprite = pinch1;
							state = State.Interpose;
						}
						else
						{
							MainSpriteRenderer.sprite = walk;
						}
					}

					break;
				case State.Interpose:
					aura.SetActive (true);
					if (Power >= 10)
					{
						Speed *= -1;
					}

					if (Power <= -1) 
					{
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

					auraSprRend.color = Color.Lerp (Color.white, Color.red, (Power / 10));
					vec.Set ((Power + 1) / 10, (Power + 1) / 10, (Power + 1) / 10);
					if (Input.GetKeyDown (KeyCode.Space))
					{
						MainSpriteRenderer.sprite = nuki;
						PowerPre = Power;
						Flag = true;
						state = State.Initializ;
					}
					Power += Speed;
					_slider.value = Power;
					aura.transform.localScale = vec;
					break;
				case State.Initializ:

					Power = 0;
					Speed = 0.3f;
					state = State.Start;
					aura.SetActive (false);	

					break;
				default:
					break;
				}
			}

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
			}

			ObstacleUpdate ();

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
			//Destroy (HP1);
			HP1.SetActive (false);
			HitPoint -= 1;
			break;
		case 2:
			//Destroy (HP2);
			HP2.SetActive (false);
			HitPoint -= 1;
			break;
		case 3:
			//Destroy (HP3);
			HP3.SetActive (false);
			HitPoint -= 1;
			break;
		default:
			break;
		}
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		Check = true;
		if (obj != null) 
		{
			sliderObj.SetActive (true);
		}
		else
		{
			
			if (collider.gameObject.tag == "Soft") 
			{
				obj = collider.gameObject;
				kubProper.SetActive (true);
				type = Type.kub;
			} 
			else if (collider.gameObject.tag=="Hard") 
			{
				obj = collider.gameObject;
				pilePropel.SetActive (true);
				pile_pull_Proper.SetActive (true);
				pullSliderObj.SetActive (true);
				type = Type.pile;
			}
			else if (collider.gameObject.tag=="Huge")
			{
				obj = collider.gameObject;
				polePropel.SetActive (true);
				pullSliderObj.SetActive (true);
				type = Type.pole;
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		Check = false;
		ObjInit ();

		if (kubProper.activeInHierarchy == true) 
		{
			kubProper.SetActive (false);
		}
		if (pilePropel.activeInHierarchy == true) 
		{
			pilePropel.SetActive (false);
		}
		if (pile_pull_Proper.activeInHierarchy == true) 
		{
			pile_pull_Proper.SetActive (false);	
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

	