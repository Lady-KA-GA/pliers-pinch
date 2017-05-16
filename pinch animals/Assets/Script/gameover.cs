using UnityEngine;
using System.Collections;

public class gameover : MonoBehaviour 
{
	public GameObject kub0;
	public GameObject kub1;
	public GameObject kub2;
	public GameObject kub3;


	public GameObject pileFlag;

	public GameObject OverFlag;

	public static bool overCheck;

	private AudioSource gameover_se;

	void Start ()
	{
		overCheck = false;
		gameover_se = GetComponent<AudioSource>();
	}


	void Update ()
	{
		bool PiF = pileFlag.activeInHierarchy;
		bool KuF0 = kub0.activeInHierarchy;
		bool KuF1 = kub1.activeInHierarchy;
		bool KuF2 = kub2.activeInHierarchy;
		bool KuF3 = kub3.activeInHierarchy;

		if (PiF == false ||
			KuF0 == false ||
			KuF1 == false ||
			KuF2 == false ||
			KuF3 == false)
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
