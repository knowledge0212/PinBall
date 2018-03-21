using UnityEngine;

public class ScoreLargeCloudController : ScoreController {

	void OnCollisionEnter(Collision other){
		culculateScore (75);
	}
}
