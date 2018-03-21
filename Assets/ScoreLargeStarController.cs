using UnityEngine;

public class ScoreLargeStarController : ScoreController {

	void OnCollisionEnter(Collision other){
		culculateScore (25);
	}
}
