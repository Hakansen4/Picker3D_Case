using UnityEngine;

public abstract class ScreenBaseState
{
    public abstract void OpenScreen(ScreenStateManager screen);

    public abstract void UpdateScreen(ScreenStateManager screen);

    public abstract void CloseScreen(ScreenStateManager screen);
}
