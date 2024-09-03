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
        Debug.Log("random" + RandomSpawn.copySpawn);
        Debug.Log("count" + Inventory.count2);
        if (RandomSpawn.copySpawn == Inventory.count2)
            SceneManager.LoadScene("ScoreScene");

    }
}
