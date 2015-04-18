using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int m_count;

	void Start(){
		m_count = 0;
		winText.text = "";
		SetCountText ();
	}

	void FixedUpdate(){
		float move_horizontal = Input.GetAxis ("Horizontal");
		float move_vertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (move_horizontal, 0.0f, move_vertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			m_count++;
			SetCountText ();
		}

		if (other.gameObject.tag == "CeilTrigger") {
			other.gameObject.SetActive(false);
			GameObject.Find("Ceil").GetComponent<CeilController>().m_move = true;
		}

		if (other.gameObject.tag == "FloorTrigger") {
			other.gameObject.SetActive(false);
			GameObject.Find("NorthFloor").SetActive(false);
		}
	}

	void SetCountText(){
		countText.text = "Count: " + m_count.ToString ();
		if (m_count > 0) {
			winText.text = "YOU WIN!";
		}
	}
	//http://unity3d.com/learn/tutorials/projects/roll-a-ball/displaying-text
}