using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	private static long totalScore = 0;
	private GameObject scoreText;

	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find ("ScoreText");
		this.scoreText.GetComponent<Text> ().text = "Score：" + totalScore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		this.scoreText.GetComponent<Text> ().text = "Score：" + totalScore.ToString ();
	}

	public void culculateScore(int i) {
		totalScore += i;
	}
}
