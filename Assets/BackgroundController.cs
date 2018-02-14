using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	// スクロール速度
	//背景画像は遠景なのでキューブの移動速度に比べて移動速度を少し遅く設定
	private float scrollSpeed = -0.03f;
	// 背景終了位置
	private float deadLine = -16;
	// 背景開始位置
	private float startLine = 15.8f;

	// Use this for initialization
	void Start(){
	}

	// Update is called once per frame
	void Update () {
		// Translate関数を使って背景画像を左方向に移動
		transform.Translate (this.scrollSpeed, 0, 0);

		// 画面外に出たら、画面右端に移動する
		//背景画像が左端（背景のx座標がdeadLine変数より小さい値）までスクロールしたら
		//画面右端のstartLine変数の位置に戻す
		if (transform.position.x < this.deadLine ) {
			transform.position = new Vector2 (this.startLine, 0);
		}
	}
}