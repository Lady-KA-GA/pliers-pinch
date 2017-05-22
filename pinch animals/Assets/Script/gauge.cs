using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gauge: MonoBehaviour 
{
	public Slider _slider;

	public GameObject auraObj;

	public bool Flag;

	public bool pullFlag;
	public float Power;
	public float powerPre;
	float Speed;

	public SpriteRenderer auraSprRend;//オーラのスプライトレンダラー

	public Sprite auraSpr1;//オーラの差分１
	public Sprite auraSpr2;//オーラの差分２
	public Sprite auraSpr3;//オーラの差分３

	Vector3 vec;
	public int a = 0;

	public enum State
	{
		Start,
		Interpose,
		Initializ
	};

	public State state;

	void Start()
	{
		state = State.Start;
		//state = State.Interpose;
	}

	void Update()
	{

	}

	public void testFunc()
	{
		switch (state) 
		{
		case State.Start:
			state = State.Interpose;
			break;

		case State.Interpose:
			auraObj.SetActive (true);
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
				powerPre = Power;
				Flag = true;
				state = State.Initializ;
			}
			Power += Speed;
			_slider.value = Power;
			auraObj.transform.localScale = vec;
			break;

		case State.Initializ:

			Power = 0;
			Speed = 0.3f;
			state = State.Start;
			auraObj.SetActive (false);	

			break;
		default:
			break;
		}
	}


	public void testFunction()
	{
		switch (state) 
		{
		case State.Start:
				state = State.Interpose;
			break;

		case State.Interpose:
			auraObj.SetActive (true);
			if (Power >= 10) 
			{
				Speed *= -1;
			}

			if (Power <= -1) 
			{
				Speed *= -1;
			}
				
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				if (Power >= 3 && Power <= 7) 
				{
					a += 1;
				}
				powerPre = Power;
				//state = State.Initializ;
			}
			Power += Speed;
			_slider.value = Power;

			if (a == 3) 
			{
				state = State.Initializ;
			}
			break;
		case State.Initializ:

			Power = 0;
			Speed = 0.3f;
			state = State.Start;
			auraObj.SetActive (false);	

			break;
		default:
			break;
		}
	}

}