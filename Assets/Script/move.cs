using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;

    //游戏是否胜利
    private bool win;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        win = GetComponent <score>().getWinStatic();
    }

    // Update is called once per frame
    void Update()
    {
        win = GetComponent<score>().getWinStatic();
        if (win == false) {
            //Horizontal水平轴 Vertical垂直轴 Mouse X鼠标水平滚轮轴 Mouse Y鼠标垂直滚轮轴
            float right_left = Input.GetAxis("Horizontal");
            //UnityEngine.Debug.Log(right_left);

            float back_forward = Input.GetAxis("Vertical");
            //UnityEngine.Debug.Log(back_forward);

            //unity的坐标系是左手系所以上下方向为Z轴
            rb.AddForce(new Vector3(right_left * 2, 0, back_forward * 2));
        };

    }
}
