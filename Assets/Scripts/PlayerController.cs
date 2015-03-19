using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	void FixedUpdate(){
		float move_horizontal = Input.GetAxis ("Horizontal");
		float move_vertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (move_horizontal, 0.0f, move_vertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}
}