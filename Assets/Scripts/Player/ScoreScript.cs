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
        SceneManager.LoadScene("Menue");

    }
}
