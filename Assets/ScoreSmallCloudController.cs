using UnityEngine;

public class ScoreSmallCloudController : ScoreController {

	void OnCollisionEnter(Collision other){
		culculateScore (50);
	}
}
