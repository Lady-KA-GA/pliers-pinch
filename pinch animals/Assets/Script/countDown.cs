using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countDown : MonoBehaviour 
{
	public Sprite nom0;
	public Sprite nom1;
	public Sprite nom2;
	public Sprite nom3;

	Sprite img;

	public GameObject player;

	float sec;

	void Start () 
	{
		img = GetComponent<Image> ().sprite;
	}

	void Update () 
	{
		sec = player.GetComponent<Player2> ().PullTime;

		if (sec == 0.0f) 
		{
			img = nom3;
		}
		if (sec >= 1.0f) 
		{
			img = nom2;
		}
		if (sec >= 2.0f) 
		{
			img = nom1;
		}

		GetComponent<Image> ().sprite = img;
	}
}
