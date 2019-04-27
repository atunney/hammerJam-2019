using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletOrigin : MonoBehaviour {

	public GameObject[] flushablePrefabs;
	public GameObject nextObject;
	public List<Transform> origins;

	public int flushablesToGenerate = 25;

	public float timeBetweenFlushes = 4.5f;

	public Queue<GameObject> incoming = new Queue<GameObject>();

	void Awake() {

		foreach (Transform child in transform) {
			origins.Add(child);
		}

		for (int i = 0; i < flushablesToGenerate; i++) {
			int next = Random.Range(0, flushablePrefabs.Length - 1);
			int location = Random.Range(0, origins.Count - 1);
			
			GameObject f = Instantiate(flushablePrefabs[next], origins[location]);
			f.SetActive(false);

			incoming.Enqueue(f);
		}
		incoming.Peek().SetActive(true);
		Invoke("LaunchNext", timeBetweenFlushes * 2.5f);
	}

	void Update() {
		if (Input.GetKeyDown("space")) {
			CancelInvoke();
			LaunchNext();
		}
	}

	public void LaunchNext() {

		GameObject nextObject = incoming.Dequeue();
		nextObject.GetComponent<Flushable>().isActive = true;		

		Invoke("LaunchNext", timeBetweenFlushes);

		incoming.Peek().SetActive(true);

	}


}
