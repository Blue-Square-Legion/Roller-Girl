using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

using UnityEditor.Experimental;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public
    TextMeshProUGUI _timeText;
    public TextMeshProUGUI ItemsText;
    float num = 0;
    bool recieve = false;
    bool give = false;
    // Start is called before the first frame update
    float seconds = 0;

    void Start()
    {
        if (!ItemsText)
            ItemsText = GetComponent<TextMeshProUGUI>();

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
           
            give = false;
        }

    }

    void Items(float num)
    {

      
        ItemsText.text = num.ToString()+" items";
    }

    void Update()
    {
        if (seconds <= 100)
        {
            _timeText.text = seconds.ToString();
            seconds= seconds+1*Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && recieve)
        {
            num = num + 5;         
        }
        Items(num);
        if (Input.GetMouseButtonDown(0) && give)
        {
            if (num >= 1)
                num = num - 1;
        }
        Items(num);

    }
}