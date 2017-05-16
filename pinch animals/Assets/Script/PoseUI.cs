using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UIコンポーネントの使用

//ポーズUIのオンオフを管理するクラス
public class PoseUI : MonoBehaviour 
{
	public GameObject poseui;

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
	}
	
	// Update is called once per frame
	void Update () 
	{
		//ポーズ画面ではないなら
		if (Pose.i == false)
		{
			//ポーズ画面でない状態ならばボタン（UIグループ）を無効化
			if (poseui.gameObject.activeSelf)
			{
				poseui.gameObject.SetActive(false);
			}
		}
		//ポーズ画面であれば
		else 
		{
			//ポーズ画面であればボタン（UIグループ）を有効化
			if (poseui.gameObject.activeSelf == false)
			{
				poseui.gameObject.SetActive(true);
			}
		}
	}
}
