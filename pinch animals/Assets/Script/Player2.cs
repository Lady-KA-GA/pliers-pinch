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

	public Sprite damage;


	public Animator anim;

	//public GameObject animObj;

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

	public float CoolTime;

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

	GameObject ObjPre;

	int horizon;
	int vertical;


	float RoZ;

	float RoSpeed;

	bool JudgeF;

	bool coolFlag;

	bool FuncFlag;

	public GameObject lage;
	public GameObject mid;
	public GameObject smool;

	public GameObject nice;
	public GameObject bad;

	private float nextTime;
	public float interval = 1.0f;	// 点滅周期

	bool DamageFlag;

	bool pinchFlag;

	private AudioSource hasamu_se;
	private AudioSource nuku_se;

	private AudioSource[] sources;

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

	public enum HardState
	{
		GaugeStart,
		Wait,
		ControlStart,
		Initializ
	};


	public State state;
	public Type type;
	public HardState hardState;

	void Start ()
	{

		SPEED = new Vector2(0.05f, 0.05f);//プレイヤーの移動速度
		Check = false;

		Power = 0;
		PowerPre = 0;
		pullPower = 0;
		pullSpeed = 1.2f;
		rigid2D = GetComponent<Rigidbody2D>();//同じゲームオブジェクト貼られているリジッドボディへの参照（ポインタ）を取得
		Flag=false;
		DeathFlag = false;
		pullFlag = false;
		PullTime = 0;

		Count = 0;

		obj = null;

		HitPoint = 3;

		ObjChild = null;

		RoZ = 0;

		RoSpeed = 1;

		JudgeF = false;

		CoolTime = 1.0f;

		coolFlag = false;

		hardState = HardState.GaugeStart;

		FuncFlag = false;

		horizon = 0;

		vertical = 0;

		nextTime = Time.time;

		pinchFlag = false;

		//AudioSourceコンポーネントを取得し、変数に格納
		AudioSource[] audioSources = GetComponents<AudioSource>();
		//hasamu_se = audioSources[0];
		//nuku_se = audioSources[1];

		sources = gameObject.GetComponents<AudioSource>();
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
				
				if (Flag && PowerPre <= 0.99f)
				{
					DamageFlag = true;
					nice.SetActive (false);
					bad.SetActive (true);
					MainSpriteRenderer.sprite = damage;
					HitPointFunction ();
					Flag = false;
				}
				if (Flag && (PowerPre >= 1.00f && PowerPre <= 3.00f)) 
				{
					nice.SetActive (true);
					bad.SetActive (false);

					anim.SetBool ("pinch", false);
					anim.SetTrigger ("nuku");

					vertical = 20;
					ObjChild.GetComponent<CircleCollider2D> ().enabled = true;
					obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					obj.GetComponent<Rigidbody2D> ().angularVelocity = 1000.0f;
					obj.GetComponent<Rigidbody2D> ().velocity = new Vector3 (obj.GetComponent<Rigidbody2D> ().velocity.x, vertical, 0);
					Flag = false;
				} 

				if (Flag && PowerPre >= 3.001f)
				{
					DamageFlag = true;
					nice.SetActive (false);
					bad.SetActive (true);

					HitPointFunction ();
					Flag = false;
				}

				JudgeF = ObjChild.GetComponent<CircleCollider2D> ().enabled;

				break;

			case Type.pile:

				switch (hardState)
				{
				case HardState.GaugeStart:
					if (Flag && PowerPre <= 3.99f)
					{
						DamageFlag = true;
						nice.SetActive (false);
						bad.SetActive (true);

						MainSpriteRenderer.sprite = damage;
						HitPointFunction ();
						Flag = false;
						hardState = HardState.Initializ;
					}
					if (Flag && (PowerPre >= 4.00f && PowerPre <= 6.00f)) 
					{

						nice.SetActive (true);
						bad.SetActive (false);

						pinchFlag = true;

						Flag = false;
						pullFlag = true;
						pullPower = 0;
						hardState = HardState.Wait;
					}
					if (Flag && PowerPre >= 6.01f)
					{
						DamageFlag = true;
						nice.SetActive (false);
						bad.SetActive (true);

						HitPointFunction ();
						Flag = false;
						hardState = HardState.Initializ;
					}
					break;

				case HardState.Wait:
					if (pullFlag == true) 
					{
						CoolTime -= Time.deltaTime;
						pullPower = pullPower + (Time.deltaTime * 5);
						if (CoolTime <= 0.0f)
						{
							CoolTime = 1.0f;
							hardState = HardState.ControlStart;
						}
						pullSlider.value = pullPower;
					}
					else 
					{
						hardState = HardState.Initializ;
					}
					break;

				case HardState.ControlStart:

					if (pullFlag == true)
					{
						FuncFlag = true;
						Numbel.SetActive (true);
						if (Input.GetKeyDown (KeyCode.Space)) 
						{
							pullPower += pullSpeed;
						}
						else 
						{
							pullPower -= 0.08f;
						}

						if (FuncFlag == true) 
						{
							if (pullPower <= 2.9f) 
							{
								DamageFlag = true;
								nice.SetActive (false);
								bad.SetActive (true);

								HitPointFunction ();
								hardState = HardState.Initializ;
								FuncFlag = false;
								pullFlag = false;
							}

							if (pullPower >= 3.0f && pullPower <= 7.0f)
							{
								nice.SetActive (true);
								bad.SetActive (false);
								PullTime += Time.deltaTime;
								FuncFlag = false;
							}

							if (pullPower >= 7.1f) 
							{
								DamageFlag = true;
								nice.SetActive (false);
								bad.SetActive (true);

								HitPointFunction ();
								hardState = HardState.Initializ;
								FuncFlag = false;
								pullFlag = false;
							}

							if (PullTime >= 3.0f)
							{

								anim.SetBool ("pinch", false);
								anim.SetTrigger ("nuku");

								nice.SetActive (true);
								bad.SetActive (false);

								vertical = 30;
								horizon = -10;
								PullTime = 0;
								pullPower = 5;
								ObjChild.GetComponent<CircleCollider2D> ().enabled = true;
								obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
								ObjChild.GetComponent<PolygonCollider2D> ().enabled = true;
								obj.GetComponent<Rigidbody2D> ().velocity = new Vector3 (horizon, vertical, 0);
								obj.GetComponent<Rigidbody2D> ().angularVelocity = 1000.0f;

								pullFlag = false;
								Numbel.SetActive (false);
								hardState = HardState.Initializ;
							}

							pullSlider.value = pullPower;
						}
					}
					JudgeF = ObjChild.GetComponent<PolygonCollider2D> ().enabled;
					break;

				case HardState.Initializ:

					PowerPre = 0;	
					hardState = HardState.GaugeStart;

					break;
				default:
					break;
				}

				break;

			case Type.pole:

				Vector2 PosVec = obj.transform.position;
				PosVec.y = 2.96f;

				switch (hardState)
				{
				case HardState.GaugeStart:
					if (Flag && PowerPre <= 6.99f)
					{
						DamageFlag = true;
						nice.SetActive (false);
						bad.SetActive (true);

						HitPointFunction ();
						Flag = false;
						hardState = HardState.Initializ;
					}

					if (Flag && (PowerPre >= 7.00f && PowerPre <= 9.00f)) 
					{
						nice.SetActive (true);
						bad.SetActive (false);

						hardState = HardState.Wait;
						Flag = false;
						pullFlag = true;
						pullPower = 0;
						Count = 0;

						obj.GetComponent<EdgeCollider2D> ().enabled = true;
						hardState = HardState.Wait;
					}

					if (Flag && PowerPre >= 9.01f) 
					{
						DamageFlag = true;
						nice.SetActive (false);
						bad.SetActive (true);
						HitPointFunction ();
						Flag = false;
						hardState = HardState.Initializ;
					}
					break;

				case HardState.Wait:
					if (pullFlag == true)
					{
						hardState = HardState.ControlStart;
					}
					break;

				case HardState.ControlStart:
					if (pullFlag == true)
					{
						int Ang0 = 10;
						int Ang1 = 16;
						int Ang2 = 21;
						int Ang3 = 26;

						switch (Count) 
						{
						case 0:
							lage.SetActive (true);
							lage.transform.position = PosVec;
							if (RoZ >= Ang0) 
							{
								RoSpeed *= -1;
							}
							if (RoZ <= Ang0 * -1) 
							{
								RoSpeed *= -1;
							}
							
							if (Input.GetKeyDown (KeyCode.Space)) 
							{
								if (RoZ >= -7 && RoZ <= 7) 
								{
									nice.SetActive (true);
									bad.SetActive (false);

									Count += 1;
									pullPower += 3;
									lage.SetActive (false);
								} 
								else
								{
									DamageFlag = true;

									nice.SetActive (false);
									bad.SetActive (true);

									HitPointFunction ();
									hardState = HardState.Initializ;
								}

							}
							break;

						case 1:
							mid.SetActive (true);
							mid.transform.position = PosVec;
							if (RoZ >= Ang1) 
							{
								RoSpeed *= -1;
							}
							if (RoZ <= Ang1 * -1) 
							{
								RoSpeed *= -1;
							}
							if (Input.GetKeyDown (KeyCode.Space)) 
							{
								if (RoZ >= -3 && RoZ <= 3) 
								{
									Count += 1;
									pullPower += 3;
									mid.SetActive (false);
								} 
								else
								{
									DamageFlag = true;

									nice.SetActive (false);
									bad.SetActive (true);

									HitPointFunction ();
									hardState = HardState.Initializ;
								}
							}
							break;

						case 2:
							smool.SetActive (true);
							smool.transform.position = PosVec;
							if (RoZ >= Ang2)
							{
								RoSpeed *= -1;
							}
							if (RoZ <= Ang2 * -1)
							{
								RoSpeed *= -1;
							}

							if (Input.GetKeyDown (KeyCode.Space))
							{
								if (RoZ >= -1 && RoZ <= 1) 
								{
									Count += 1;
									pullPower += 4;
									smool.SetActive (false);
								}
								else 
								{
									DamageFlag = true;

									nice.SetActive (false);
									bad.SetActive (true);

									HitPointFunction ();
									hardState = HardState.Initializ;
								}
							}
							break;
						case 3:
							if (pullPower >= 10.0f) 
							{
								anim.SetBool ("pinch", false);
								anim.SetTrigger ("nuku");

								vertical = 20;
								obj.GetComponent<Rigidbody2D> ().velocity = new Vector3 (obj.GetComponent<Rigidbody2D> ().velocity.x, vertical, 0);
								ObjChild.GetComponent<BoxCollider2D> ().enabled = true;
								ObjChild.GetComponent<CircleCollider2D> ().enabled = true;
								obj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
								obj.GetComponent<Rigidbody2D> ().angularVelocity = 1000.0f;
								pullFlag = false;
								hardState = HardState.Initializ;
							}
							break;
						default:
							break;
						}
						RoZ += RoSpeed;

						pullSlider.value = pullPower;

						Vector3 RVec = new Vector3 (0.0f, 0.0f, RoZ);

						obj.transform.eulerAngles = RVec;
					}
					break;

				case HardState.Initializ:
					RoZ = 0;
					pullPower = 0;
					Count = 0;

					hardState = HardState.GaugeStart;
					break;
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
		if (obj != null) 
		{
			switch (state) 
			{
			case State.Start:
				if (pullFlag != true) 
				{
					if (Input.GetKeyDown (KeyCode.Space)) 
					{
						anim.SetBool ("pinch", true);
						MainSpriteRenderer.sprite = pinch1;
						state = State.Interpose;
							//hasamu_se.PlayOneShot(hasamu_se.clip);
							sources[0].Play();

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
			bool WalkFlag = false;
			if (Input.GetKey (KeyCode.LeftArrow))
			{
				Rotation.y = 0;
				Position.x -= SPEED.x;
				state = State.Initializ;
				WalkFlag = true;
			}

			if (Input.GetKey (KeyCode.RightArrow)) 
			{
				Rotation.y = 180;
				Position.x += SPEED.x;
				state = State.Initializ;
				WalkFlag = true;
			}

			if (WalkFlag == true) 
			{
				anim.SetBool ("walk", true);
			} 
			else 
			{
				anim.SetBool ("walk", false);
			}
		}

		if (DamageFlag == true) 
		{
			anim.SetBool ("pinch", false);
			anim.SetTrigger ("damage 0");
			if ( Time.time > nextTime ) 
			{
				playspr.GetComponent<Renderer> ().enabled = !playspr.GetComponent<Renderer> ().enabled;

				nextTime += interval;
			}
			else
			{
				playspr.GetComponent<Renderer> ().enabled = true;
				DamageFlag = false;
			}
		}

		ObstacleUpdate ();

		transform.position = Position;
		transform.eulerAngles = Rotation;
	}

	void HitPointFunction()
	{
		switch(HitPoint)
		{
		case 1:
			DeathFlag = true;
			HP1.SetActive (false);
			HitPoint -= 1;
			break;
		case 2:
			HP2.SetActive (false);
			HitPoint -= 1;
			break;
		case 3:
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
			nice.SetActive (false);
			bad.SetActive (false);
		}
		if (pullSliderObj.activeInHierarchy == true) 
		{
			pullSliderObj.SetActive (false);
		}
	}
}

	