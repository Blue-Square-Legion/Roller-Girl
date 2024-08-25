using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

using UnityEditor.Experimental;
using UnityEngine.SceneManagement;


public class Inventory : MonoBehaviour
{
    [SerializeField]
    public
    TextMeshProUGUI _timeText;
    public TextMeshProUGUI ItemsText;
    float f = 8f;
    float num = 0;
    bool recieve = false;
    bool give = false;
    // Start is called before the first frame update
    float seconds = 100;
    bool timeUp = false;
    
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
    public IEnumerator Show()
    {
        SceneManager.LoadScene("ScoreScene");
        yield return new WaitForSeconds(f);   
    }

    void Update()
    {
        if (seconds <= 100&& seconds>=0)
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