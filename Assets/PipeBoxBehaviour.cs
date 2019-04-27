using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBoxBehaviour : MonoBehaviour {

	private static List<PipeBoxBehaviour> pipeBoxes = new List<PipeBoxBehaviour>();
	private static int selectedPipeIndex = 0;

	private static int pipeCount = 0;
	private static int pieceCount;

	private float moveDelay = 1f;
	private static float inputDelay = 0.06f;
	private static bool acceptingInput = true;

	private Vector2[] pieceLocations = new Vector2[4];

	public Queue<PipeBehaviour> pieces = new Queue<PipeBehaviour>();

	PipeBehaviour currentPipe;


	void Awake() {

		pieceLocations[0] = new Vector2(transform.position.x, transform.position.y + 3);
		pieceLocations[1] = new Vector2(transform.position.x, transform.position.y + 1);
		pieceLocations[2] = new Vector2(transform.position.x, transform.position.y - 1);
		pieceLocations[3] = new Vector2(transform.position.x, transform.position.y - 3);

		if (!pipeBoxes.Contains(this)) {
			pipeBoxes.Add(this);
			pipeCount++;
		}

		pipeBoxes.Sort(XPositionComparison);

		PipeBehaviour[] pb = GetComponentsInChildren<PipeBehaviour>();
		List<PipeBehaviour> pipes = new List<PipeBehaviour>();

		pieceCount = pb.Length;

		foreach (PipeBehaviour p in pb) {
			pipes.Add(p);
		}

		pipes.Sort(YPositionComparison);
		
		for (int i = 0; i < pieceCount; i++) {
			pieces.Enqueue(pipes[i]);	
		}
			
	}

	void Update() {
		
		if (acceptingInput) {
			
			if (Input.GetButtonDown("PipeDrop") && pipeBoxes[selectedPipeIndex] == this) {

				Debug.Log("Pipe box: " + selectedPipeIndex + " drop");

				pipeBoxes[selectedPipeIndex].pieces.Peek().Drop();

				acceptingInput = false;

				Invoke("MovePieces", moveDelay);

			} else if (Input.GetButtonDown("PipeLeft")) {
				selectedPipeIndex--;
				selectedPipeIndex = Mathf.Max(0, selectedPipeIndex);
				Debug.Log("Selected:" + selectedPipeIndex);
				acceptingInput = false;
				Invoke("EnableInput", inputDelay);
			} else if (Input.GetButtonDown("PipeRight")) {
				selectedPipeIndex++;
				selectedPipeIndex = Mathf.Min(pipeCount - 1, selectedPipeIndex);
				Debug.Log("Selected:" + selectedPipeIndex);
				acceptingInput = false;
				Invoke("EnableInput", inputDelay);
			}
		}
	}

	
    private static int YPositionComparison(PipeBehaviour a, PipeBehaviour b)
    {
        if (a == null) return (b == null) ? 0 : -1;
        if (b == null) return 1;
 
        var ya = a.transform.position.y;
        var yb = b.transform.position.y;
        return ya.CompareTo(yb); 
    }

	private static int XPositionComparison(PipeBoxBehaviour a, PipeBoxBehaviour b)
	{
		if (a == null) return (b == null) ? 0 : -1;
		if (b == null) return 1;

		var xa = a.transform.position.x;
		var xb = b.transform.position.x;
		return xa.CompareTo(xb); 
	}

	void MovePieces() {
		Debug.Log("move pieces called");

		PipeBehaviour dropped = pieces.Dequeue();
		dropped.transform.rotation = Quaternion.identity;
		dropped.transform.position = pieceLocations[0];

		for (int i = pipeBoxes.Count; i > 0; i--) {					
			PipeBehaviour iPiece = pieces.Dequeue();
			iPiece.transform.rotation = Quaternion.identity;
			iPiece.transform.position = pieceLocations[i];
			
			iPiece.Freeze();
			pieces.Enqueue(iPiece);
			iPiece.RandomRotation();
		}
		
		
		dropped.Freeze();
		pieces.Enqueue(dropped);
		dropped.RandomRotation();

		EnableInput();
	}

	void EnableInput() {		
		acceptingInput = true;
		CancelInvoke();
	}




}
