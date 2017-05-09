using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	SpriteRenderer MainSpriteRenderer;

	public GameObject playspr;

	public Sprite StandbySprite;
	public Sprite HoldSprite;
	public Sprite SlashSprite;
	public static bool Flag;

	void Start ()
	{
		MainSpriteRenderer = playspr.GetComponent<SpriteRenderer>();
		Flag = false;
	}

	void Update ()
	{
		ChangeState ();
	}

	void ChangeState()
	{
		if (Input.GetKey ("space")) 
		{
			MainSpriteRenderer.sprite = HoldSprite;
			Flag = true;
		}
		else 
		{
			MainSpriteRenderer.sprite = SlashSprite;
			Flag = false;
		}
	}
}
