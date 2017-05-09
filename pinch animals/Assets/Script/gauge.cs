using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gauge : MonoBehaviour 
{
	public Slider _slider;
	float Power;
	float Speed;

	public bool Flag;

	public bool Press;

	void Start () 
	{
		// スライダーを取得する
		//_slider = GameObject.Find("Slider").GetComponent<Slider>();

		Power = 0;
		Speed = 0.0f;

		Flag = false;

		Press = false;
	}

	void Init()
	{
		Power = 0;
		Speed = 0.1f;
	}


	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			if (Press == false) 
			{
				Press = true;
			} 
			else 
			{
				Press = false;
			}
		}

		if (Press == true)
		{
			if (Power > 10) 
			{
				Speed = -0.1f;
			} 
			else if(Power == 0)
			{
				Speed = 0.1f;
			}
		}
		else
		{
			Speed = 0;
		}


	}
}