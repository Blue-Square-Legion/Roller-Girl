using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
public class Inventory : MonoBehaviour
{

    public TextMeshProUGUI ItemsText;
    float num = 0;
    bool recieve = false;
    bool give = false;
    // Start is called before the first frame update
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


        if (Input.GetKey(KeyCode.M) && recieve)
        {
            num = num + 1;

            Debug.Log("M");
        }
        Items(num);
        if (Input.GetKey(KeyCode.L) && give)
        {

            if (num >= 1)
                num = num - 1;
           

            Debug.Log("L");
        }
        Items(num);

    }
}