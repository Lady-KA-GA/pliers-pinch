using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour 
{
	//次のシーンの名前
	public string nextScene;
	//遷移したかどうかを保存する変数
	bool Moved = false;


	public bool clearFlag;
	public bool overFlag;


	private AudioSource space_se;//抜く時になるSE


	void Start ()
    {
      //  AudioManager.Instance.PlayBGM("");
       // AudioManager.Instance.PlaySE("");
        //nextScene = null;
		space_se = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () 
	{
		clearFlag = kub_pile_Flag.clearCheck;
		overFlag = gameover.overCheck;

        //Debug.Log (nextScene);
        if (!Moved)
        {
			switch (Application.loadedLevelName) 
			{
			case "title":
               	     /*次のシーンに遷移する方法*/
				if (Input.GetKeyDown ("space"))
				{

						ChangeScene();
					
					}
				break;
			case "stage_select":
		/*		if (Input.GetMouseButtonDown (0))
				{
					ChangeScene();
				}*/
				break;
			case "stage1":
				if ((clearFlag == true || overFlag == true) && Input.GetKeyDown(KeyCode.Space))
				{
					ChangeScene ();
				}
				break;
			case "stage2":
				if ((clearFlag == true || overFlag == true) && Input.GetKeyDown(KeyCode.Space))
				{
					ChangeScene ();
				}
				break;
			case "stage3":
				if (Input.GetKeyDown(KeyCode.A))
				{
					ChangeScene ();
				}
				break;
			}
		}

        if (nextScene == SceneManager.GetActiveScene().name)
        {
            //次のシーンをnull
            //nextScene = null;
            //Debug.Log(" null or NotNull:::" + nextScene);
            Moved = false;
        }
		/*	if ((nextScene != null) && (Moved == false))
            {
                Debug.Log ("nextScene name:::" + nextScene);
                Moved = true;
                //シーンの遷移
                FadeManager.Instance.LoadLevel (nextScene, 2.0f);

            }

            if(nextScene == SceneManager.GetActiveScene().name)
            {
                //次のシーンをnull
                nextScene = null;
                Debug.Log(" null or NotNull:::" + nextScene);
                Moved = false;
            }*/

		/*if (Input.GetKeyDown("space"))
		{
			space_se.PlayOneShot(space_se.clip);
		}*/
	}

	void Awake() 
	{ 
	
	}


	public void ChangeScene() 
	{
		space_se.PlayOneShot(space_se.clip);
		FadeManager.Instance.LoadLevel(nextScene, 0.5f);
        Moved = true;        
    }
	public void StringArgFunction(string s)
	{
		//SceneManager.LoadScene (s);
		space_se.PlayOneShot(space_se.clip);
		FadeManager.Instance.LoadLevel(s, 0.5f);
		Debug.Log("シーン"+s);
	}
}
