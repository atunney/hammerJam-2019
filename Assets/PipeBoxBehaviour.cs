using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBoxBehaviour : MonoBehaviour {

	public static List<PipeBoxBehaviour> pipeBoxes;
	public int selectedPipeIndex = 0;

	void Awake() {
		if (!pipeBoxes.Contains(this)) {
			pipeBoxes.Add(this);
		}
	}


	void Update() {
		if (Input.GetKeyDown("s") && pipeBoxes[selectedPipeIndex] == this) {
			Debug.Log("Pipe box: " + selectedPipeIndex + " drop");
		}


	}


}
