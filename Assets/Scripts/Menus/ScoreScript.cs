using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{

    public TextMeshProUGUI ScoreText;
    int score;
    float second2 = 20f;
    public Button Menue;
    public Button Restart;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
      //  Menue = gameObject.GetComponent<Button>();

     //   Restart = gameObject.GetComponent<Button>();


    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Main_Demo()
    {
        SceneManager.LoadScene("Main_Demo");
        Inventory._check = false;
    }

   
    // Update is called once per frame
    void Update()
    {

        ScoreText.text ="The score is : " + Inventory.score.ToString();
    }
}
