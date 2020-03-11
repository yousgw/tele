using System.Collections;
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
        if (CheckGrounded())
        {
            //Debug.Log("Ground");
            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * 100);
                Debug.Log("Jump");
            }
        }
        if (Input.GetKey(KeyCode.A)) transform.Rotate(new Vector3(0, -1, 0));
        if (Input.GetKey(KeyCode.D)) transform.Rotate(new Vector3(0, 1, 0));
        if (Input.GetKey(KeyCode.W)) transform.position += transform.forward * 0.1f;
        if (Input.GetKey(KeyCode.S)) transform.position += transform.forward * -0.1f;
        if (Input.GetMouseButtonDown(0))
        {
            GameObject tele_ball = Instantiate(ball, transform.position+transform.forward*1.0f, transform.rotation);
            Rigidbody t_b_rb = tele_ball.GetComponent<Rigidbody>();
            force = transform.forward*1000 + new Vector3(0,1,0)*500;
            t_b_rb.AddForce(force);
        }

    }

    public bool CheckGrounded()
    {
        //CharacterControlle.IsGroundedがtrueならRaycastを使わずに判定終了
        if (controller.isGrounded) { return true; }
        //放つ光線の初期位置と姿勢
        //若干身体にめり込ませた位置から発射しないと正しく判定できない時がある
        var ray = new Ray(this.transform.position + Vector3.up * 0.1f, Vector3.down);
        //探索距離
        var tolerance = 0.55f;
        int layerMask = ~(1 << 8);
        //Raycastがhitするかどうかで判定
        //地面にのみ衝突するようにレイヤを指定する
        return Physics.Raycast(this.transform.position + Vector3.up * 0.1f, Vector3.down, tolerance, layerMask);
    }
}
