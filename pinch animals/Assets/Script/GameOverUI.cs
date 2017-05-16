using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UIコンポーネントの使用

//ポーズUIのオンオフを管理するクラス
public class GameOverUI : MonoBehaviour 
{
	public GameObject gameoverui;

	public Button Stage;

	void Start()
	{
		// ボタンコンポーネントの取得
		//Stage = GameObject.Find("/Canvas/PoseUI/Button").GetComponent<Button>();

		if (Stage != null)
		{
			// 最初に選択状態にしたいボタンの設定
			Stage.Select();
		}

		Debug.Log("gameoverui");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//ゲームオーバー画面ではないなら
		if (gameover.overCheck == false)
		{
			//ゲームオーバー画面でない状態ならばボタン（UIグループ）を無効化
			if (gameoverui.gameObject.activeSelf)
			{
				gameoverui.gameObject.SetActive(false);
				//Debug.Log("s");
			}
		}
		//ゲームオーバー画面画面であれば
		else 
		{
			//ゲームオーバー画面であればボタン（UIグループ）を有効化
			if (gameoverui.gameObject.activeSelf == false)
			{
				Debug.Log("GOUI ON");
				gameoverui.gameObject.SetActive(true);
				//Debug.Break();
			}
		}
	}
}