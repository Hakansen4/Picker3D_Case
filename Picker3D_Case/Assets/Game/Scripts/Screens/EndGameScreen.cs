using UnityEngine;

public class EndGameScreen : ScreenBaseState
{
    private bool IsPassed = false;
    private GameObject endGameScreen;

    public EndGameScreen(GameObject screen)
    {
        endGameScreen = screen;
    }

    public override void CloseScreen(ScreenStateManager screen)
    {
        endGameScreen.SetActive(false);
    }

    public void DefineIsPassed(bool IsPassed)
    {
        this.IsPassed = IsPassed;
    }
    public override void OpenScreen(ScreenStateManager screen)
    {
        endGameScreen.SetActive(true);
        if (IsPassed)
            Debug.Log("Passed");
        else
            Debug.Log("Failed");
    }

    public override void UpdateScreen(ScreenStateManager screen)
    {

    }
}
