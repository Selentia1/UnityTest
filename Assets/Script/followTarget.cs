using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTrans;
    Vector3 offset;
    void Start() 
    {
        playerTrans = GameObject.Find("player").transform;
        offset = transform.position - playerTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + playerTrans.position;
    }
}
