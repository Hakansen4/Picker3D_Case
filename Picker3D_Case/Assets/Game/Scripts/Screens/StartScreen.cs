using UnityEngine;
using Ambrosia.EventBus;

public class StartScreen : ScreenBaseState
{
    private GameObject startScreen;
    
    
    public StartScreen(GameObject Screen)
    {
        startScreen = Screen;
    }

    public override void CloseScreen(ScreenStateManager screen)
    {
        startScreen.SetActive(false);
    }

    public override void OpenScreen(ScreenStateManager screen)
    {
        startScreen.SetActive(true);
    }

    public override void UpdateScreen(ScreenStateManager screen)
    {
        if(InputManager.IsSpacePressed())
        {
            EventBus<Event_StartGame>.Emit(this, new Event_StartGame());
        }
    }
}
