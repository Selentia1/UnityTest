using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class jump : MonoBehaviour
{
    public Rigidbody rb;
    //����ϵ��
    public float gravityScale = 3;
    //��Ծ����Ҫ��������mass*10
    public float jumpforce = 15f;

    //�ж������Ƿ�Ӵ�������
    private bool closeGround = true;
    //�ж������Ƿ��ڽ�����Ծ
    private bool isJump = false;
    //�������������ϵ��
    public float chageDown = 1.2f;
    public float chageUp = 0.9f;

    //��Ϸ�Ƿ�ʤ��
    private bool win;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        win = GetComponent<score>().getWinStatic();
    }

    // Update is called once per frame 
    void Update()
    {
        //��Ծ
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

    //�̶�֡,update����ǰƽ̨��֡���йأ���FixedUpdate����ʵʱ��
    //���Դ��������߼���ʱ��Ҫ�Ѵ������FixedUpdate������Update.
    private void FixedUpdate()
    {
        //��Ծʱ����������������������ʱ���ٶȸ���,�����������
        Vector3 gravityChage = Physics.gravity * gravityScale - Physics.gravity;
        rb.AddForce(gravityChage, ForceMode.Acceleration);

        //��Ծʱ�����������������������ٶȸ���
        if (rb.velocity.y > 0)
        {
            rb.AddForce(gravityChage * chageUp, ForceMode.Acceleration);
        }
        else if (rb.velocity.y <= 0) {
            rb.AddForce(gravityChage * chageDown, ForceMode.Acceleration);
        }

    }

    //�͵������ײ���
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            closeGround = true;
        }
    }
}
