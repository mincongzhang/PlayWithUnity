using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	private bool m_forward,m_backward,m_forwarded,m_backwarded, m_forever_stop;
	private float m_move_count,m_forward_speed,m_backward_speed,m_door_height;
	private int m_stop_count;

	void Start(){
		m_forward = false;
		m_backward = false;
		m_forwarded = false;
		m_backwarded = false; 
		m_forever_stop = false;

		m_move_count = 0F;
		m_forward_speed = 1F;
		m_backward_speed = - 5 * m_forward_speed;

		m_door_height = 3.1F;
	}

	// Update is called once per frame
	void Update () {
		if(m_forward && !m_forever_stop){
			transform.Translate (new Vector3 (0, m_forward_speed, 0) * Time.deltaTime);
			m_move_count += m_forward_speed * Time.deltaTime;
			if(m_move_count > m_door_height){
				m_backward = true;
				m_forward = false;
				m_forwarded = true;
			}
		} 
		if (m_backward && !m_forever_stop) {
			transform.Translate (new Vector3 (0, m_backward_speed, 0) * Time.deltaTime);
			m_move_count += m_backward_speed * Time.deltaTime;
			if(m_move_count < 0.0F){
				m_backwarded = true;
			}
		}
		if (m_forwarded && m_backwarded) {
			m_forever_stop = true;
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player")
			m_forward = true;
	}

	/*
	 * tick "is Trigger" if you want to do this
	 * The object won't be a physical object afterwards
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			m_forward = true;
		}
	}
	*/
}
