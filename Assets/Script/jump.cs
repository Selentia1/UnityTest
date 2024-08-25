using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class jump : MonoBehaviour
{
    public Rigidbody rb;
    //重力系数
    public float gravityScale = 3;
    //跳跃力需要大于质量mass*10
    public float jumpforce = 15f;

    //判断物体是否接触到地面
    private bool closeGround = true;
    //判断物体是否在进行跳跃
    private bool isJump = false;
    //重力上下落调整系数
    public float chageDown = 1.2f;
    public float chageUp = 0.9f;

    //游戏是否胜利
    private bool win;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        win = GetComponent<score>().getWinStatic();
    }

    // Update is called once per frame 
    void Update()
    {
        //跳跃
        win = GetComponent<score>().getWinStatic();
        if (win == false) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (closeGround && isJump == false)
                {
                    closeGround = false;
                    rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
                }
            }
        }
    }

    //固定帧,update跟当前平台的帧数有关，而FixedUpdate是真实时间
    //所以处理物理逻辑的时候要把代码放在FixedUpdate而不是Update.
    private void FixedUpdate()
    {
        //跳跃时重力调整，让物体上下落时的速度更快,解决浮跳问题
        Vector3 gravityChage = Physics.gravity * gravityScale - Physics.gravity;
        rb.AddForce(gravityChage, ForceMode.Acceleration);

        //跳跃时上下落重力调整，让下落速度更快
        if (rb.velocity.y > 0)
        {
            rb.AddForce(gravityChage * chageUp, ForceMode.Acceleration);
        }
        else if (rb.velocity.y <= 0) {
            rb.AddForce(gravityChage * chageDown, ForceMode.Acceleration);
        }

    }

    //和地面的碰撞检测
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            closeGround = true;
        }
    }
}
