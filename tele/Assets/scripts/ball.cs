using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

	private Vector3 p, b;
	private CharacterController controller;
	private float distance;
	
	public GameObject player;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		p = player.transform.position;
		b = this.transform.position;
		distance = Vector3.Distance(p, b);
		//Debug.Log(distance);
		if (distance >= 10.0f) Destroy(this.gameObject);
	}

	void OnCollisionStay(Collision other)
	{
		player.transform.position = transform.position;
		if (distance >= 10.0f) Destroy(this.gameObject);
	}
}
