using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;

    //��Ϸ�Ƿ�ʤ��
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
            //Horizontalˮƽ�� Vertical��ֱ�� Mouse X���ˮƽ������ Mouse Y��괹ֱ������
            float right_left = Input.GetAxis("Horizontal");
            //UnityEngine.Debug.Log(right_left);

            float back_forward = Input.GetAxis("Vertical");
            //UnityEngine.Debug.Log(back_forward);

            //unity������ϵ������ϵ�������·���ΪZ��
            rb.AddForce(new Vector3(right_left * 2, 0, back_forward * 2));
        };

    }
}
