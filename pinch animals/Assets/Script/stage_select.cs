using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UIコンポーネントの使用

public class stage_select : MonoBehaviour 
{
	Button Stage1B;
	Button Stage2B;
	Button Stage3B;

	void Start () 
	{
		// ボタンコンポーネントの取得
		Stage1B = GameObject.Find ("/Canvas/stage1_button").GetComponent<Button> ();
		Stage2B = GameObject.Find ("/Canvas/stage2_button").GetComponent<Button> ();
		Stage3B = GameObject.Find ("/Canvas/stage3_button").GetComponent<Button> ();

		// 最初に選択状態にしたいボタンの設定
		Stage1B.Select ();
	}
}