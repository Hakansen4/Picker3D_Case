using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenStateManager : MonoBehaviour
{
    [SerializeField] private GameObject _StartScreen;
    [SerializeField] private GameObject _PlayScreen;
    [SerializeField] private GameObject _EndGameScreen;


    private ScreenBaseState state;
    private StartScreen startScreen;
    private PlayScreen playScreen;
    private EndGameScreen endScreen;

    private void Awake()
    {
        startScreen = new StartScreen(_StartScreen);
        playScreen = new PlayScreen(_PlayScreen);
        endScreen = new EndGameScreen(_EndGameScreen);

        state = startScreen;
        state.OpenScreen(this);
    }
    private void Update()
    {
        state.UpdateScreen(this);
    }

    private void ChangeState(ScreenStates screenState)
    {
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
