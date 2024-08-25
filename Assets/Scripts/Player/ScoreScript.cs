using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreScript : MonoBehaviour
{

    public TextMeshProUGUI ScoreText;
    int score;
    float second2 = 20f;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }
    public void SetScore(int scoreUpdate)
    {
        PlayerPrefs.SetInt("score",scoreUpdate);
    }
    public int GetScore(int score)
    {
       return PlayerPrefs.GetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 0)
        SetScore(10);
     int x=   GetScore(score);
        ScoreText.text = "The score is : "+ x.ToString();
        if (second2 <= 20)
        {
            second2 -= Time.deltaTime;
            SceneManager.GetSceneByBuildIndex(1);
            if(second2<=8 ) 
            SceneManager.LoadScene("Menue");
        }
    }
}
