﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 moveDirection, force;

    public GameObject ball;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space)) moveDirection.y = 5;
        }
        if (Input.GetKey(KeyCode.A)) transform.Rotate(new Vector3(0, -1, 0));
        if (Input.GetKey(KeyCode.D)) transform.Rotate(new Vector3(0, 1, 0));
        if (Input.GetKey(KeyCode.W)) transform.position += transform.forward * 0.1f;
        if (Input.GetKey(KeyCode.S)) transform.position += transform.forward * -0.1f;
        if (Input.GetMouseButtonDown(0))
        {
            GameObject tele_ball = Instantiate(ball, transform.position+transform.forward*0.52f, transform.rotation);
            Rigidbody t_b_rb = tele_ball.GetComponent<Rigidbody>();
            force = transform.forward*1000 + new Vector3(0,1,0)*500;
            t_b_rb.AddForce(force);
        }


        moveDirection.y -= 10 * Time.deltaTime; //重力計算
        controller.Move(moveDirection * Time.deltaTime); //cubeを動かす処理

    }
}
