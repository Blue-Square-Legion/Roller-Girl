using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button begin;
    public Button end;  
    // Start is called before the first frame update
    void Start()
    {
        begin = gameObject.GetComponent<Button>();
        end = gameObject.GetComponent<Button>();


    }
    public void Begin()
    {
        SceneManager.LoadScene("Main_Demo");
    }
    public void End()
    {
        SceneManager.LoadScene("TestPattern");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
