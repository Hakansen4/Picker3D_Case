using UnityEngine;
using Ambrosia.EventBus;
using System;
using UnityEngine.UI;
using TMPro;

public class ScreenStateManager : MonoBehaviour
{
    [Header("Start Screen")]
    [SerializeField] private GameObject _StartScreen;

    [Header("Play Screen")]
    [SerializeField] private Material _GreenColor;
    [SerializeField] private GameObject _PlayScreen;
    [SerializeField] private Image[] _BlockRenderers;
    [SerializeField] private TextMeshProUGUI _LevelText;
    [SerializeField] private TextMeshProUGUI _NextLevelText;

    [Header("End Game Screen")]
    [SerializeField] private GameObject _LevelFailedScreen;
    [SerializeField] private GameObject _LevelPassedScreen;
    [SerializeField] private Button _RestartLevelButton;
    [SerializeField] private Button _NextLevelButton;


    private ScreenBaseState state;
    private StartScreen startScreen;
    private PlayScreen playScreen;
    private EndGameScreen endScreen;

    private void Awake()
    {
        startScreen = new StartScreen(_StartScreen);
        playScreen = new PlayScreen(_PlayScreen, _BlockRenderers, _GreenColor, _LevelText, _NextLevelText);
        endScreen = new EndGameScreen(_LevelFailedScreen, _LevelPassedScreen, _RestartLevelButton, _NextLevelButton);

        state = startScreen;
        state.OpenScreen(this);
    }
    private void OnEnable()
    {
        EventBus<Event_StartGame>.AddListener(GameStarted);
        EventBus<Event_LevelFailed>.AddListener(LevelFailed);
        EventBus<Event_LevelPassed>.AddListener(LevelPassed);
        
        playScreen.SubEvents();
        endScreen.SetButtons();
    }
    private void OnDisable()
    {
        EventBus<Event_StartGame>.RemoveListener(GameStarted);
        EventBus<Event_LevelFailed>.RemoveListener(LevelFailed);
        EventBus<Event_LevelPassed>.RemoveListener(LevelPassed);

        playScreen.UnSubEvents();
    }

    private void LevelPassed(object sender, Event_LevelPassed @event)
    {
        endScreen.DefineIsPassed(true);
        ChangeState(ScreenStates.EndGameScreen);
    }

    private void LevelFailed(object sender, Event_LevelFailed @event)
    {
        endScreen.DefineIsPassed(false);
        ChangeState(ScreenStates.EndGameScreen);
    }

    private void GameStarted(object sender, Event_StartGame @event)
    {
        ChangeState(ScreenStates.PlayScreen);
    }

    private void Update()
    {
        state.UpdateScreen(this);
    }

    private void ChangeState(ScreenStates screenState)
    {
        state.CloseScreen(this);
        switch (screenState)
        {
            case ScreenStates.StartScreen:
                state = startScreen;
                break;
            case ScreenStates.PlayScreen:
                state = playScreen;
                break;
            case ScreenStates.EndGameScreen:
                state = endScreen;
                break;
            default:
                break;
        }
        state.OpenScreen(this);
    }
}

public enum ScreenStates
{
    StartScreen,PlayScreen,EndGameScreen
};
