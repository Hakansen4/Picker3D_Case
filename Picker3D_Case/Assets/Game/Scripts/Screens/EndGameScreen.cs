using UnityEngine;
using Ambrosia.EventBus;
using UnityEngine.UI;
using System;

public class EndGameScreen : ScreenBaseState
{
    private bool IsPassed = false;
    private GameObject levelFailedScreen;
    private GameObject levelPassedScreen;
    private Button restartLevelButton;
    private Button nextLevelButton;

    public EndGameScreen(GameObject levelFailedScreen, GameObject levelPassedScreen, Button restartLevelButton, Button nextLevelButton)
    {
        this.levelFailedScreen = levelFailedScreen;
        this.levelPassedScreen = levelPassedScreen;
        this.restartLevelButton = restartLevelButton;
        this.nextLevelButton = nextLevelButton;
    }
    public void SetButtons()
    {
        restartLevelButton.onClick.AddListener(RestartLevel);
        nextLevelButton.onClick.AddListener(NextLevel);
    }

    private void NextLevel()
    {
        EventBus<Event_LoadNextLevel>.Emit(this, new Event_LoadNextLevel());
    }

    private void RestartLevel()
    {
        EventBus<Event_RestartLevel>.Emit(this, new Event_RestartLevel());
    }

    public override void CloseScreen(ScreenStateManager screen)
    {
        levelFailedScreen.SetActive(false);
        levelPassedScreen.SetActive(false);
    }

    public void DefineIsPassed(bool IsPassed)
    {
        this.IsPassed = IsPassed;
    }
    public override void OpenScreen(ScreenStateManager screen)
    {
        if (IsPassed)
            levelPassedScreen.SetActive(true);
        else
            levelFailedScreen.SetActive(true);
    }

    public override void UpdateScreen(ScreenStateManager screen)
    {

    }
}
