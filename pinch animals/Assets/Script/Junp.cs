using UnityEngine;
using System.Collections;

public class Junp : MonoBehaviour 
{
	void Start () 
	{
		
	}

	void Update () 
	{
		
	}
	public bool characterInQuicksand = false;

	void OnTriggerEnter2D(Collider2D other) 
	{
		characterInQuicksand = true;
	}
/*	// プレハブを取得
	GameObject prefab = (GameObject)Resources.Load("Prefabs/Effects/Prefab名");

	Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
	// プレハブからインスタンスを生成
	GameObject obj = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
	// 作成したオブジェクトを子として登録
	obj.transform.parent = transform;*/
}
