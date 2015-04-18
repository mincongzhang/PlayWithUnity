using UnityEngine;
using System.Collections;

public class CeilController : MonoBehaviour {

	public bool m_move;
	private float m_move_count;
	private float m_speed;
	private float m_height;

	// Use this for initialization
	void Start () {
		m_move = false;
		m_move_count = 0.0F;
		m_speed = 0.5F;
		m_height = 3.1F;
	}
	
	// Update is called once per frame
	void Update () {
		if (m_move && m_move_count<m_height) {
			transform.Translate (new Vector3 (-m_speed, 0, 0) * Time.deltaTime);
			m_move_count += m_speed * Time.deltaTime;
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player")
			m_move = false;
		   /*Then player die*/
	}
}
