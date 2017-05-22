using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour 
{
	//次のシーンの名前
	public string nextScene;
	//遷移したかどうかを保存する変数
	bool Moved = false;

	bool clearFlag;
	bool overFlag;

	void Start ()
    {
      //  AudioManager.Instance.PlayBGM("");
       // AudioManager.Instance.PlaySE("");
        //nextScene = null;
    }
	
	// Update is called once per frame
	void Update () 
	{
		//ここで滅茶苦茶エラー吐かれる
		//これが出来たら画面遷移完了。
		//タイトルから遷移する時に必要
		clearFlag = clearflag.Check;
		overFlag = Player2.DeathFlag;

        //Debug.Log (nextScene);
        if (!Moved)
        {
			switch (Application.loadedLevelName) 
			{
			case "title":
               	     /*次のシーンに遷移する方法*/
				if (Input.GetKeyDown ("space"))
				{
					ChangeScene ();
				}
				break;
			case "stage_select":
		/*		if (Input.GetMouseButtonDown (0))
				{
					ChangeScene();
				}*/
				break;
			case "stage1_mukai":
				if ((clearFlag == true || overFlag == true) && Input.GetKeyDown(KeyCode.Space))
				{
					ChangeScene ();
				}
				break;
			case "stage2_mukai":
				if ((clearFlag == true || overFlag == true) && Input.GetKeyDown(KeyCode.Space))
				{
					ChangeScene ();
				}
				break;
			case "stage3":
				if ((clearFlag == true || overFlag == true) && Input.GetKeyDown(KeyCode.Space))
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
    }
	public void ChangeScene() 
	{
		FadeManager.Instance.LoadLevel(nextScene, 0.5f);
            Moved = true;        
    }
	public void StringArgFunction(string s)
	{
		SceneManager.LoadScene (s);
	}
}
