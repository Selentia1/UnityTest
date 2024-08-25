using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class score : MonoBehaviour
{
    //分数
    public int gameScore;
    public Text scoreTxet;
    
    //胜利条件
    public Text winText;
    bool win = false;
    public int foodAmount;
    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
        scoreTxet = GameObject.Find("ScoreText").GetComponent<Text>();
        winText = GameObject.Find("WinText").GetComponent<Text>();
        winText.gameObject.SetActive(win);
        foodAmount = GameObject.FindGameObjectsWithTag("FOOD").Length;
        Debug.Log(foodAmount);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FOOD")
        {
            other.gameObject.SetActive(false);
            gameScore++;
            scoreTxet.text = "Score:" + gameScore;
        } 
        if (gameScore == foodAmount) {
            win = true;
            winText.gameObject.SetActive(win);
            Vector3 currentVelocity = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
    }

    public bool getWinStatic() {
        return win;
    }
}
