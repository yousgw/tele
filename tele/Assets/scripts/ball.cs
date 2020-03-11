using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

	private Vector3 p, b, point;
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
		if (distance >= 20.0f) Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider other)
	{

		player.transform.position = b ;
		Destroy(this.gameObject);
		
		
		Debug.Log("touch  "+other.gameObject.name+b+player.transform.position);
	}

	void OnCollisionEnter(Collision other)
	{
		/*
		point = transform.position + new Vector3(-1,-1,-1);
		if (distance >= 10.0f) Destroy(this.gameObject);
		player.transform.position = point;
		*/
		Debug.Log("touch  " + other.gameObject.name + transform.position);
	}
}
