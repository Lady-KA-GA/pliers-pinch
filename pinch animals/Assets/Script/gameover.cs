using UnityEngine;
using System.Collections;

public class gameover : MonoBehaviour 
{
	public GameObject obj0;
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;


	public GameObject objFlag;

	public GameObject OverFlag;

	public static bool overCheck;


	public bool PlayerDeath;

	private AudioSource gameover_se;


	void Start ()
	{
		overCheck = false;
		gameover_se = GetComponent<AudioSource>();
	}


	void Update ()
	{
		bool objF = objFlag.activeInHierarchy;
		bool objF0 = obj0.activeInHierarchy;
		bool objF1 = obj1.activeInHierarchy;
		bool objF2 = obj2.activeInHierarchy;
		bool objF3 = obj3.activeInHierarchy;

		PlayerDeath = Player3.DeathFlag;

		if (objF == false ||
			objF0 == false ||
			objF1 == false ||
			objF2 == false ||
			objF3 == false ||
			PlayerDeath == true	)
			/*if(Input.GetKey(KeyCode.A))*/
		{
			overCheck = true;
			OverFlag.gameObject.SetActive (true);
			transform.position.Set (0, 0, 0);
			gameover_se.PlayOneShot(gameover_se.clip);
			Debug.Log("ゲームオーバー");

		}
	}
}
