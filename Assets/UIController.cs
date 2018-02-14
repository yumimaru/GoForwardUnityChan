using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
//↑スクリプトでシーンに関するクラスを使うため（追加8.1）

public class UIController : MonoBehaviour {

	// ゲームオーバテキスト
	private GameObject gameOverText;

	// 走行距離テキスト
	private GameObject runLengthText;

	// 走った距離
	private float len = 0;

	// 走る速度
	private float speed = 0.03f;

	// ゲームオーバの判定
	private bool isGameOver = false;

	// Use this for initialization
	void Start () {
		//作成した2つのUI(GameOverとRunLength)に表示する文字列を更新するため、
		// Find関数を使ってシーン中からこれらのオブジェクトを探し
		//gameOverText変数とrunLengthText変数にそれぞれ代入
		this.gameOverText  = GameObject.Find ("GameOver");
		this.runLengthText = GameObject.Find ("RunLength");
	}

	// Update is called once per frame
	void Update () {
		if (this.isGameOver == false){
			// 走った距離を更新する
			//len変数にspeed変数を加算して走行距離を算出
			this.len += this.speed;

			//runLengthText変数のtextに代入するときは
			//len.ToString ("F2")としてlen変数をToString関数を使って文字列に変換
			// 走った距離を表示する
			//※「ToString()」は浮動小数点の数値を文字列に変換する。引数には文字列に変換する際の書式を指定
			//引数を"F2"とすることで、小数部を2桁まで表示するように書式指定
			this.runLengthText.GetComponent<Text> ().text = "Distance:  "  + len.ToString ("F2") + "m";
		}

		// ゲームオーバになった場合
		if (this.isGameOver) {
			// クリックされたらシーンをロードする（追加8.1）
			if (Input.GetMouseButtonDown (0)) {
				//GameSceneを読み込む（追加8.1）
				//SceneManagerクラスのLoadScene関数を使うとシーンを読み込むことができる
				//引数には読み込むシーン名を渡す
				//ここでは"GameScene"を渡して同じシーンを再読み込みすることでリスタート
				SceneManager.LoadScene ("GameScene");
			}
		}
	}

	public void GameOver()        {
		// GameOverのtextに「GameOver」の文字列を代入して画面に表示
		//ゲームオーバになったときに、UnityChanControllerがこの関数を呼ぶ
		this.gameOverText.GetComponent<Text>().text = "GameOver";
		this.isGameOver = true;
	}

}