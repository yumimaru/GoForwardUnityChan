using UnityEngine;
using System.Collections;

public class CubeGenerator : MonoBehaviour {

	// キューブのPrefab
	public GameObject cubePrefab;

	// 時間計測用の変数
	private  float delta = 0;

	// キューブの生成間隔
	//span変数で指定した時間間隔ごとにキューブを生成
	private  float span = 1.0f;

	// キューブの生成位置：X座標
	private float genPosX = 12;

	// キューブの生成位置オフセット
	private float offsetY = 0.3f;
	// キューブの縦方向の間隔
	private float spaceY = 6.9f;

	// キューブの生成位置オフセット
	private float offsetX = 0.5f;
	// キューブの横方向の間隔
	private float spaceX = 0.4f;

	// キューブの生成個数の上限
	private int maxBlockNum = 4;

	// Use this for initialization
	void Start(){
	}

	// Update is called once per frame
	void Update () {

		//フレームごとにdelta変数にフレーム間の時間差を足していく
		//「Time.deltaTime」でフレーム間の時間の差分を取得できる
		this.delta += Time.deltaTime;

			// span秒以上の時間が経過したかを調べる
		//deltaがspanの値を超えたタイミングでキューブを生成
		if ( this.delta > this.span ){
			this.delta = 0;
			// 生成するキューブ数をランダムに決める
			//個数をRandom.Range関数で決めて高さがランダムになるように生成
			int n = Random.Range (1, maxBlockNum+1);

			// 指定した数だけキューブを生成する
			for (int i = 0; i < n; i++){
				// キューブの生成
				//段階的に落ちるよう、縦方向にspaceY変数のぶんだけスペースを空けて生成
				GameObject go = Instantiate (cubePrefab) as GameObject;
				go.transform.position = new Vector2 (this.genPosX, this.offsetY + i * this.spaceY);
			}
			// 次のキューブまでの生成時間を決める
			//生成するキューブの数が少ない場合は次の生成までの間隔を短くし、数が多い場合は次の生成までの間隔を長く
			this.span = this.offsetX + this.spaceX * n;
		}
	}
}