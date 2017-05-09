using UnityEngine;
using System.Collections;

public class Pose : MonoBehaviour 
{
	SpriteRenderer MainSpriteRenderer;
	public Sprite AxisSpriteRenderer;
	public Sprite ChangeSpriteRenderer;

	public static bool i;


	void Start () 
	{
		MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		i = false;
	}


	void Update () 
	{

		switch(i)
		{
		case true:
			MainSpriteRenderer.sprite = ChangeSpriteRenderer;
			Time.timeScale = 0;
			if (Input.GetKeyDown (KeyCode.Escape)) 
			{
				i = false;
			}
			break;
		case false:
			MainSpriteRenderer.sprite = AxisSpriteRenderer;
			Time.timeScale = 1;
			if (Input.GetKeyDown (KeyCode.Escape)) 
			{
				i = true;
			}
			break;

		}
	}
}
