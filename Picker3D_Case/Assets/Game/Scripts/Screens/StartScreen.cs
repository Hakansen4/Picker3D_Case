using UnityEngine;

public class StartScreen : ScreenBaseState
{
    private GameObject startScreen;
    
    
    public StartScreen(GameObject Screen)
    {
        startScreen = Screen;
    }
    public override void OpenScreen(ScreenStateManager screen)
    {
        startScreen.SetActive(true);
    }

    public override void UpdateScreen(ScreenStateManager screen)
    {

    }
}
