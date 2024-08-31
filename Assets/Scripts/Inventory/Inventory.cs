using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

using UnityEditor.Experimental;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering;
using static UnityEngine.PlayerLoop.EarlyUpdate;


public class Inventory : MonoBehaviour
{
    public static int score;
    [SerializeField]
    public
    TextMeshProUGUI _timeText;
    public TextMeshProUGUI ItemsText;
    float f = 15f;
    float num = 0;
    bool recieve = false;
    bool give = false;
    // Start is called before the first frame update
    float seconds = 30;
    bool timeUp = false;
    bool check = false;
    int y = 0;
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("recieve"))
        {
            recieve = true;
            give = false;
        }
        if (other.gameObject.CompareTag("give"))
        {
            recieve = false;
            give = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("recieve"))
        {
            recieve =false;
            
        }
        if (other.gameObject.CompareTag("give"))
        {
           // other.gameObject.GetComponent<Renderer>().material.color=Color.blue; 
            give = false;
        }

    }

  

    public IEnumerator Show()
    {
        SceneManager.LoadScene("ScoreScene");
        yield return new WaitForSeconds(f);   
    }

    void Update()
    {

        if (seconds <= 30 && seconds>=0)
        {
            _timeText.text = UnityEngine.Mathf.RoundToInt(seconds).ToString();
            seconds -= Time.deltaTime;
            if (UnityEngine.Mathf.RoundToInt(seconds).ToString() == "0")
                StartCoroutine(Show());  
            if (seconds == 0)
                timeUp = true;
        }

        if (Input.GetMouseButtonDown(0) && recieve)
        {
            if (num < 5) 
            {
                num = num + 5;
            }
            check = false;
        }

      

        if (Input.GetMouseButtonDown(0) && give)
        {
            y++;
            if (num >= 1 && !check)
            {
                num = num - 1;
           
               
            }
           
                int h = y * 100;
                score = h;
            
        }

        ItemsText.text = num.ToString() + " items";
    }
}