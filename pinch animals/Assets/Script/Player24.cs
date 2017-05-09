using UnityEngine;
using System.Collections;

public class Player24 : MonoBehaviour
{
	public Vector2 SPEED = new Vector2(0.05f, 0.05f);
	public bool Check;

	SpriteRenderer MainSpriteRenderer;

	public GameObject playspr;

	public Sprite StandbySprite;
	public Sprite HoldSprite;
	public Sprite SlashSprite;


	GameObject obj=null;

	void Start () 
	{
		Check = false;
		MainSpriteRenderer = playspr.GetComponent<SpriteRenderer>();
	}


	void Update ()
	{
		Vector2 Position = transform.position;
		Vector2 Rotation = transform.eulerAngles;

		if (Input.GetKey ("space")) 
		{
			MainSpriteRenderer.sprite = HoldSprite;
/*			if (obj != null) 
			{
				transform.parent = obj.transform;
			}*/
		}
		else 
		{
			MainSpriteRenderer.sprite = SlashSprite;
			//transform.parent = null;

			if (Input.GetButton ("Fire1")) 
			{
				Position.x -= SPEED.x;
			}
			if (Input.GetButton ("Fire2")) 
			{
				Position.x += SPEED.x;
			}

			if (Input.GetKey ("a")) 
			{
				Rotation.y = 0;
				Position.x -= SPEED.x;
			}

			if (Input.GetKey ("d")) 
			{
				Rotation.y = 180;
				Position.x += SPEED.x;
			}

			if (Check == true) {
				if (Input.GetKeyDown ("w")) 
				{
					Position.y += SPEED.y + 2;
					Check = false;
				}
			}
			transform.position = Position;
			transform.eulerAngles = Rotation;
		}

	}
	/*
	// 移動関数
	void Move()
	{
		Vector2 Position = transform.position;
		Vector2 Rotation = transform.eulerAngles;

		if ( Input.GetButton("Fire1"))
		{
			Position.x -= SPEED.x;
		}
		if (Input.GetButton("Fire2"))
		{
			Position.x += SPEED.x;
		}

		if (Input.GetKey ("a"))
		{
			Rotation.y = 0;
			Position.x -= SPEED.x;
		}

		if (Input.GetKey ("d"))
		{
			Rotation.y = 180;
			Position.x += SPEED.x;
		}

		if (Check == true)
		{
			if (Input.GetKeyDown ("w"))
			{
				Position.y += SPEED.y+2;
				Check = false;
			}
		}
		transform.position = Position;
		transform.eulerAngles = Rotation;
	}
	*/
	void OnTriggerStay2D(Collider2D collider)
	{
		Check = true;
		if (collider.gameObject.name == "kub") {
			obj = collider.gameObject;
		}
	}
	/*
	void OnTriggerStay2D(Collider2D collider)
	{
		string Pliers = LayerMask.LayerToName (collider.gameObject.layer);

		if (Pliers == "pliers") 
		{
			Check = true;
		}
	}

	bool OnTriggerStay2D(Collider2D collider)
	{
		string Pliers = LayerMask.LayerToName (collider.gameObject.layer);

		if (Pliers == "pliers") {
			return true;
		} else {
			return false;
		}
	}



	void ChangeState()
	{
	}
}	*/
}