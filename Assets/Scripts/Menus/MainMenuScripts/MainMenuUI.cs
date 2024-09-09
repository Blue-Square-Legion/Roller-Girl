using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class MainMenuUI : MonoBehaviour
{
    private Button presstoStartButton;

    private Button playButton;
    private Button settingsButton;
    private Button controlsButton;
    private Button creditsButton;
    private Button quitButton;   
    //private Button displayButton;
    private Button audioOptionsButton;

    private Button settingsBackButton;
    private Button audioOptionsBackButton;
    private Button controlsScreenBackButton;
    private Button creditsScreenBackButton;

    private VisualElement introScreen;
    private VisualElement introMSG;
    private Button clickHereButton;
    private Button startGameButton;

    private VisualElement titleScreen;
    private VisualElement mainMenu;
    private VisualElement settingsScreen;
    private VisualElement audioOptions;
    public GameObject optionsScreen;
    private VisualElement controlsScreen;
    private VisualElement creditsScreen;
    //private VisualElement displayOptions;

    void Start()
    {
        optionsScreen.SetActive(false);

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        presstoStartButton = root.Q<Button>("PresstoStartButton");

        introScreen = root.Q<VisualElement>("IntroScreen");
        introMSG = root.Q<VisualElement>("IntroMSG");
        clickHereButton = root.Q<Button>("ClickHereButton");
        startGameButton = root.Q<Button>("StartGameButton");

        titleScreen = root.Q<VisualElement>("TitleScreen");
        mainMenu = root.Q<VisualElement>("MainMenu");
        settingsScreen = root.Q<VisualElement>("SettingsScreen");
        audioOptions = root.Q<VisualElement>("AudioOptions");
        controlsScreen = root.Q<VisualElement>("ControlsScreen");
        creditsScreen = root.Q<VisualElement>("CreditsScreen");

        playButton = root.Q<Button>("PlayButton");
        settingsButton = root.Q<Button>("SettingsButton");
        controlsButton = root.Q<Button>("ControlsButton");
        creditsButton = root.Q<Button>("CreditsButton");
        quitButton = root.Q<Button>("QuitButton");

        //displayButton = root.Q<Button>("DisplayButton");
        audioOptionsButton = root.Q<Button>("AudioOptionsButton");
        settingsBackButton = root.Q<Button>("SettingsBackButton");
        creditsScreenBackButton = root.Q<Button>("CreditsScreenBackButton");

        audioOptionsBackButton = root.Q<Button>("AudioOptionsBackButton");
        controlsScreenBackButton = root.Q<Button>("ControlsScreenBackButton");

        presstoStartButton.RegisterCallback<ClickEvent>(OnPresstoStartButtonClicked);

        clickHereButton.RegisterCallback<ClickEvent>(OnClickHereButtonClicked);
        startGameButton.RegisterCallback<ClickEvent>(OnStartGameButtonClicked);

        playButton.RegisterCallback<ClickEvent>(OnPlayButtonClicked);
        settingsButton.RegisterCallback<ClickEvent>(OnSettingsButtonClicked);
        controlsButton.RegisterCallback<ClickEvent>(OnControlsButtonClicked);
        creditsButton.RegisterCallback<ClickEvent>(OnCreditsButtonClicked);
        //quitButton.RegisterCallback<ClickEvent>(OnQuitButtonClicked);

        //displayButton.RegisterCallback<ClickEvent>(OnDisplayButtonClicked);
        audioOptionsButton.RegisterCallback<ClickEvent>(OnAudioOptionsButtonClicked);
        settingsBackButton.RegisterCallback<ClickEvent>(OnSettingsBackButtonClicked);
        creditsScreenBackButton.RegisterCallback<ClickEvent>(OnCreditsScreenBackButtonClicked);

        audioOptionsBackButton.RegisterCallback<ClickEvent>(OnAudioOptionsBackButtonClicked);
        controlsScreenBackButton.RegisterCallback<ClickEvent>(OnControlScreenBackButtonClicked);

        titleScreen.style.display = DisplayStyle.Flex;
        mainMenu.style.display = DisplayStyle.None;
        settingsScreen.style.display = DisplayStyle.None;
        audioOptions.style.display = DisplayStyle.None;
        controlsScreen.style.display = DisplayStyle.None;
        introScreen.style.display = DisplayStyle.None;
        introMSG.style.display = DisplayStyle.None;
        startGameButton.style.display = DisplayStyle.None;
        //displayOptions.style.display = DisplayStyle.None;
    }

    

    private void OnPresstoStartButtonClicked(ClickEvent clickEvent)
    {
        titleScreen.style.display = DisplayStyle.None;
        mainMenu.style.display = DisplayStyle.Flex;
    }

    private void OnClickHereButtonClicked(ClickEvent clickEvent) { introMSG.style.display = DisplayStyle.None; startGameButton.style.display = DisplayStyle.Flex; }
    private void OnStartGameButtonClicked(ClickEvent clickEvent) { SceneManager.LoadScene("Main_Demo", LoadSceneMode.Single); }

    private void OnPlayButtonClicked(ClickEvent clickEvent)
    {
        introScreen.style.display = DisplayStyle.Flex;
        introMSG.style.display = DisplayStyle.Flex;
    }
    private void OnSettingsButtonClicked(ClickEvent clickEvent) { settingsScreen.style.display = DisplayStyle.Flex; mainMenu.style.display = DisplayStyle.None; }
    private void OnControlsButtonClicked(ClickEvent clickEvent) { controlsScreen.style.display = DisplayStyle.Flex; }
    private void OnCreditsButtonClicked(ClickEvent clickEvent) { creditsScreen.style.display = DisplayStyle.Flex; mainMenu.style.display = DisplayStyle.None; }
    //private void OnQuitButtonClicked(ClickEvent clickEvent) { Application.Quit(); }

    //private void OnDisplayButtonClicked(ClickEvent clickEvent) { /*displayOptions.style.display = DisplayStyle.Flex; */}
    private void OnAudioOptionsButtonClicked(ClickEvent clickEvent) 
    {   optionsScreen.SetActive(true); 
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
        mainMenu.style.display = DisplayStyle.Flex;
        creditsScreen.style.display = DisplayStyle.None;
    }
    private void OnCreditsScreenBackButtonClicked(ClickEvent clickEvent)
    {
        mainMenu.style.display = DisplayStyle.Flex;
        creditsScreen.style.display = DisplayStyle.None;
    }
}
