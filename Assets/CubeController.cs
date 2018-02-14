using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	// キューブの移動速度
	private float speed = -0.2f;

	// 消滅位置
	private float deadLine = -10;

	// Use this for initialization
	void Start(){
	}

	// Update is called once per frame
	void Update () {
		// キューブを左に移動させる
		// TransformクラスのTranslate関数は、引数に与えた値のぶんだけ現在の位置から移動
		//指定した値の座標に移動するわけではない
		//第一引数から順にX軸方向、Y軸方向、Z軸方向の移動距離を指定
		//ここでは、X軸方向にspeed変数のぶんだけ移動
		transform.Translate (this.speed, 0, 0);

		// キューブの位置を取得し、画面外に出たら破棄する
		if (transform.position.x < this.deadLine){
			Destroy (gameObject);
		}
	}
}