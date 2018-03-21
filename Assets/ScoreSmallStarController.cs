using UnityEngine;

public class ScoreSmallStarController : ScoreController {

	void OnCollisionEnter(Collision other){
		culculateScore (10);
	}
}
