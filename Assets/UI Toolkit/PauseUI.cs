using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class PauseUI : MonoBehaviour
{
    private Button resumeButton;
    private Button settingsButton;
    private Button controlsButton;
    private Button mainMenuButton;
    private Button quitButton;

    private Button displayButton;
    private Button audioOptionsButton;
    private Button settingsBackButton;

    private Button audioOptionsBackButton;
    private Button controlsScreenBackButton;

    private VisualElement mainMenu;
    private VisualElement settingsScreen;
    private VisualElement audioOptions;
    private VisualElement controlsScreen;
    [SerializeField] private GameObject optionsScreen;
    private static bool isPaused = false;

    void Start()
    {
        optionsScreen.SetActive(false);
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        mainMenu = root.Q<VisualElement>("MainMenu");
        settingsScreen = root.Q<VisualElement>("SettingsScreen");
        audioOptions = root.Q<VisualElement>("AudioOptions");
        controlsScreen = root.Q<VisualElement>("ControlsScreen");

        resumeButton = root.Q<Button>("ResumeButton");
        settingsButton = root.Q<Button>("SettingsButton");
        controlsButton = root.Q<Button>("ControlsButton");
        mainMenuButton = root.Q<Button>("MainMenuButton");
        quitButton = root.Q<Button>("QuitButton");

        displayButton = root.Q<Button>("DisplayButton");
        audioOptionsButton = root.Q<Button>("AudioOptionsButton");
        settingsBackButton = root.Q<Button>("SettingsBackButton");

        audioOptionsBackButton = root.Q<Button>("AudioOptionsBackButton");
        controlsScreenBackButton = root.Q<Button>("ControlsScreenBackButton");

        resumeButton.RegisterCallback<ClickEvent>(OnResumeButtonClicked);
        settingsButton.RegisterCallback<ClickEvent>(OnSettingsButtonClicked);
        controlsButton.RegisterCallback<ClickEvent>(OnControlsButtonClicked);
        mainMenuButton.RegisterCallback<ClickEvent>(OnMainMenuButtonClicked);
        quitButton.RegisterCallback<ClickEvent>(OnQuitButtonClicked);

        //displayButton.RegisterCallback<ClickEvent>(OnDisplayButtonClicked);
        audioOptionsButton.RegisterCallback<ClickEvent>(OnAudioOptionsButtonClicked);
        settingsBackButton.RegisterCallback<ClickEvent>(OnSettingsBackButtonClicked);

        audioOptionsBackButton.RegisterCallback<ClickEvent>(OnAudioOptionsBackButtonClicked);
        controlsScreenBackButton.RegisterCallback<ClickEvent>(OnControlScreenBackButtonClicked);

        mainMenu.style.display = DisplayStyle.None;
        settingsScreen.style.display = DisplayStyle.None;
        audioOptions.style.display = DisplayStyle.None;
        controlsScreen.style.display = DisplayStyle.None;
        //displayOptions.style.display = DisplayStyle.None;
    }
    /*
    public void Resume()
    {
        panel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
    */
    private void Pause()
    {
        //panel.SetActive(true);
        mainMenu.style.display = DisplayStyle.Flex;
        isPaused = true;
        Time.timeScale = 0f;
    }
    /*
    public void Quit()
    {
        Application.Quit();
    }
    */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                //Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    private void OnResumeButtonClicked(ClickEvent clickEvent) 
    {
        mainMenu.style.display = DisplayStyle.None;
        isPaused = false;
        Time.timeScale = 1f;
    }
    private void OnSettingsButtonClicked(ClickEvent clickEvent) { settingsScreen.style.display = DisplayStyle.Flex; mainMenu.style.display = DisplayStyle.None; }
    private void OnControlsButtonClicked(ClickEvent clickEvent) { controlsScreen.style.display = DisplayStyle.Flex; }
    private void OnMainMenuButtonClicked(ClickEvent clickEvent) 
    { 
        SceneManager.LoadScene("Menu", LoadSceneMode.Single); 
        isPaused = false;
        Time.timeScale = 1f;
    }
    private void OnQuitButtonClicked(ClickEvent clickEvent) { Application.Quit(); }

    //private void OnDisplayButtonClicked(ClickEvent clickEvent) { /*displayOptions.style.display = DisplayStyle.Flex; */}
    private void OnAudioOptionsButtonClicked(ClickEvent clickEvent)
    {
        optionsScreen.SetActive(true);
        audioOptions.style.display = DisplayStyle.Flex;
        settingsScreen.style.display = DisplayStyle.None;
    }
    private void OnSettingsBackButtonClicked(ClickEvent clickEvent)
    {
        mainMenu.style.display = DisplayStyle.Flex;
        settingsScreen.style.display = DisplayStyle.None;
    }

    private void OnAudioOptionsBackButtonClicked(ClickEvent clickEvent)
    {
        optionsScreen.SetActive(false);
        settingsScreen.style.display = DisplayStyle.Flex;
        audioOptions.style.display = DisplayStyle.None;
    }
    private void OnControlScreenBackButtonClicked(ClickEvent clickEvent)
    {
        controlsScreen.style.display = DisplayStyle.None;
        settingsScreen.style.display = DisplayStyle.Flex;
    }
}
