using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform transform;
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up);
    }
}
