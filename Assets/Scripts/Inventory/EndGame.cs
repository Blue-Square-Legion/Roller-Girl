using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] public RandomSpawn num;
    [SerializeField] public Inventory num2;
    public GameObject Player;
    int z = 0;
    // Start is called before the first frame update
    void Start()
    {
        z = Inventory.count2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(num.copySpawn);

        Debug.Log(Inventory.count2);
        if (num.copySpawn == Inventory.count2)
            SceneManager.LoadScene("ScoreScene");

    }
}
