using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

   


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (RandomSpawn.copySpawn == Inventory.count2 && Inventory.count2>0 )
        {
            SceneManager.LoadScene("ScoreScene");
             Inventory._check = false;
        }
    }
}