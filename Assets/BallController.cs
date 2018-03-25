using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//総合得点
	private long totalScore = 0;

	//ゲームオーバーを表示するテキスト
	private GameObject gameoverText;
	//得点を表示するテキスト
	private GameObject scoreText;

	// Use this for initialization
	void Start () {

		//シーンの中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		this.scoreText = GameObject.Find ("ScoreText");
		//総合得点を表示
		this.scoreText.GetComponent<Text> ().text = "Score：" + totalScore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		//総合得点を表示
		this.scoreText.GetComponent<Text> ().text = "Score：" + this.totalScore.ToString ();
		
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ){
			//GameoverTextにゲームオーバーを表示
			this.gameoverText.GetComponent<Text>().text = "Game Over";
		}
	}
	void OnCollisionEnter(Collision col){
		//ぶつかると得点更新
		if(col.gameObject.tag == "SmallStarTag"){
			this.totalScore += 10;
		}else if(col.gameObject.tag == "LargeStarTag"){
			this.totalScore += 25;
		}else if(col.gameObject.tag == "SmallCloudTag"){
			this.totalScore += 50;
		}else if(col.gameObject.tag == "LargeCloudTag"){
			this.totalScore += 75;
		}
	}
}
