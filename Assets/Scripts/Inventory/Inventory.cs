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
    public GameObject player;
    public static int score;
    [SerializeField]
    public
    TextMeshProUGUI _timeText;
    public static int count2;
    public TextMeshProUGUI ItemsText;
    float f = 15f;
    float num = 0;
    bool recieve = false;
    bool give = false;
    // Start is called before the first frame update
    float seconds = 100;
    bool timeUp = false;
    bool check = false;
    int y = 0;
    int g = 0;
    bool visited = false;
    bool numchg = false;
    public static bool _check = false;
    void Start()
    {
        count2 = 0;
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
            visited = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("recieve"))
        {
            recieve = false;

        }
        if (other.gameObject.CompareTag("give"))
        {
            // other.gameObject.GetComponent<Renderer>().material.color=Color.blue; 
            if (!visited)
            {



                Destroy(other.gameObject);
              
                count2 = count2 + 1;
                RandomSpawn.z = RandomSpawn.z - 1;
           
               
            
            }
            _check = true;

            give = false;
            visited = false;
        }

    }



    public IEnumerator Show()
    {
        SceneManager.LoadScene("ScoreScene");
        yield return new WaitForSeconds(f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 3f);
        
        if (Input.GetKeyDown(KeyCode.W))
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 3f);

        if (seconds <= 100 && seconds >= 0)
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

            if (num > 5)
            {
                num = 5;
            }

           
        }



        if (Input.GetMouseButtonDown(0) && give)
        {
            if (num >= 1 && g <= 1&&visited)
            {
                num = num - 1;
                check = true;


                y++;
                g++;
                visited = false;
            }

            numchg = false;
            int h = y * 100;
            score = h;
            g = 0;
        }
      
        ItemsText.text = num.ToString() + " items";
    }
}