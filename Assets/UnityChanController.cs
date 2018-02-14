using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour {
	//ユニティちゃんにアニメーションをさせるため
	//Animatorコンポーネントを取得してから走るアニメーションを再生する条件を設定
	Animator animator;

	//Unityちゃんを移動させるコンポーネントを入れる（追加4.5）
	Rigidbody2D rigid2D;

	// 地面の位置
	private float groundLevel = -3.0f;

	// ジャンプの速度の減衰（追加4.5）
	private float dump = 0.8f;

	// ジャンプの速度（追加4.5）
	float jumpVelocity = 20;

	// ゲームオーバになる位置（追加7.4）
	private float deadLine = -9;


	// Use this for initialization
	void Start () {
		// GetComponent関数を使ってAnimatorコンポーネントを取得
		//Animatorコンポーネントを使ってアニメーション再生をスクリプトで制御する
		this.animator = GetComponent<Animator> ();

		// Rigidbody2Dのコンポーネントを取得する（追加4.5）
		//Rigidbody2Dを使ってジャンプさせたり、ジャンプの高さを調節
		this.rigid2D = GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void Update () {
		// 走るアニメーションを再生するために、Animatorのパラメータを調節する
		//Animatorで定義しているHorizontalパラメータとisGroundパラメータの遷移条件を設定
		//条件はUnityChan2DインスペクタのAnimator項目のControllerの「UnityChan2D」をWクリックして確認
		//右方向に走るアニメーションを再生するため、Horizontalを常に1に設定
		this.animator.SetFloat("Horizontal", 1);

		// タップいたときに着地しているかどうかを調べる
		//着地している場合はisGroundをtrueに設定、右方向に走る
		bool isGround = (transform.position.y > this.groundLevel) ? false : true;
		this.animator.SetBool ("isGround", isGround);

		// ジャンプ状態のときにはボリュームを0にする（追加9.1）
		//ジャンプ中かどうかはisGround変数で判別
		//isGroundがtrueの場合は音量を1、falseの場合は音量を0
		//AudioSourceコンポーネントを取得すると同時にvolume変数に音量の値を代入
		GetComponent<AudioSource> ().volume = (isGround) ? 1 : 0;

		// 着地状態でクリックされた場合（追加4.5）
		if (Input.GetMouseButtonDown (0) && isGround) {
			// 上方向の力をかける（追加4.5）
			this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);
		}

		// クリックをやめたら上方向への速度を減速する（追加4.5）
		//押し続けた場合よりもジャンプの高さが低くなる
		//Rigidbody2Dクラスの「velocity」変数は、オブジェクトの線形速度
		if (Input.GetMouseButton (0) == false) {
			if (this.rigid2D.velocity.y > 0) {
				this.rigid2D.velocity *= this.dump;
			}

		}
				// 画面左端（ユニティちゃんのx座標がdeadLine変数より小さい値）でゲームオーバにする（追加7.4）
			if (transform.position.x < this.deadLine) {
				// UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する（追加7.4）
				//UIControllerはCanvasオブジェクトにアタッチされているため、
				//Find関数を使ってUIControllerがアタッチされているCanvasオブジェクトを検索し、
				//GetComponent関数を使ってCanvasにアタッチされているUIContorllerスクリプトを取得
				GameObject.Find ("Canvas").GetComponent<UIController> ().GameOver ();

				// ユニティちゃんを破棄する（追加）
				Destroy (gameObject);
			}

	}
}