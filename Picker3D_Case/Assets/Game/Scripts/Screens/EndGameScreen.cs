using UnityEngine;

public class EndGameScreen : ScreenBaseState
{

    private GameObject endGameScreen;

    public EndGameScreen(GameObject screen)
    {
        endGameScreen = screen;
    }

    public override void OpenScreen(ScreenStateManager screen)
    {
        endGameScreen.SetActive(true);
    }

    public override void UpdateScreen(ScreenStateManager screen)
    {

    }
}
