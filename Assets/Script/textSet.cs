using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textSet : MonoBehaviour
{
    Text textComponet;
    // Start is called before the first frame update
    void Start()
    {
        textComponet = GetComponent<Text>();
        textComponet.fontStyle = FontStyle.Normal;
        textComponet.color = Color.black;
        textComponet.fontSize = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
