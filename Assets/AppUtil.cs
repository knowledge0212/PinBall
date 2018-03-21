using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppUtil {
	private static Vector3 TouchPosition = Vector3.zero;

	public static List<TouchInfo> GetTouch(){
		List<TouchInfo> infoList = new List<TouchInfo> ();

		if (Application.isEditor) {
			if (Input.GetMouseButtonDown (0)) {
				infoList.Add (TouchInfo.Began);
			}else if(Input.GetMouseButton(0)){
				infoList.Add (TouchInfo.Stationary);
			} else if (Input.GetMouseButtonUp (0)) {
				infoList.Add (TouchInfo.Ended);
			} else {
				infoList.Add(TouchInfo.None);
			}
		} else if(Input.touchCount > 0) {
			foreach(Touch touch in Input.touches){
				infoList.Add ((TouchInfo)(int)touch.phase);
			}
		} else {
			infoList.Add(TouchInfo.None);
		}
		return infoList;
	}

	public static List<Vector3> GetTouchPosition(){

		List<Vector3> posList = new List<Vector3>();

		if (Application.isEditor) {
			List<TouchInfo> infoList = AppUtil.GetTouch ();
			if (infoList [0] != TouchInfo.None) {
				posList.Add (Input.mousePosition);
			} else {
				posList.Add (Vector3.zero);
			}
		} else if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				TouchPosition.x = touch.position.x;
				TouchPosition.y = touch.position.y;
				posList.Add (TouchPosition);
			}
		} else {
			posList.Add(Vector3.zero);
		}
		return posList;
	}
}

public enum TouchInfo {
	None = 99,
	Began = 0,
	Moved = 1,
	Stationary = 2,
	Ended = 3,
	Canceled = 4
}


