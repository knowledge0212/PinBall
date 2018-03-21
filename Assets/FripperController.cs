using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	//HingeJointコンポーネントをイッル
	private HingeJoint myHingeJoint;
	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent<HingeJoint> ();
		SetAngle (this.defaultAngle);
	}

	// Update is called once per frame
	void Update () {

		bool leftFlickFlg = false;
		bool rightFlickFlg = false;
		List<TouchInfo> infoList = AppUtil.GetTouch ();
		List<Vector3> posList = AppUtil.GetTouchPosition ();

		for(int i=0;i<infoList.Count; i++){			
			if (infoList [i] == TouchInfo.Began || infoList[i] == TouchInfo.Stationary || infoList[i] == TouchInfo.Moved) {
				if (posList [i].x >= Screen.width / 2) {
					rightFlickFlg = true;
				} else {
					leftFlickFlg = true;
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			leftFlickFlg = true;
		}

		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow)){
			rightFlickFlg = true;
		}
		if (tag == "LeftFripperTag") {
			if (leftFlickFlg) {
				SetAngle (this.flickAngle);
			} else {
				SetAngle (this.defaultAngle);
			}
		}else if (tag == "RightFripperTag") {
			if (rightFlickFlg) {
				SetAngle (this.flickAngle);
			} else {
				SetAngle (this.defaultAngle);
			}
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
