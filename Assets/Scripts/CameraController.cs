using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player1;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position;
		//player = GameObject.Find("Player").GetComponent<PlayerController>().speed; 
		//get the "ball" Player without using mouse.

	}

	// Update is called once per frame
	//LateUpdate gathering last known states, run after Update()
	void LateUpdate () {
		transform.position = player1.transform.position + offset;
	}
}