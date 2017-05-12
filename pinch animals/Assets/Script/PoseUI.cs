using UnityEngine;
using System.Collections;

//ポーズUIのオンオフを管理するクラス
public class PoseUI : MonoBehaviour 
{
	public GameObject poseui;
	
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
