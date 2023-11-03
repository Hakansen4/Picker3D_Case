using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
 
    public static bool IsSpacePressed()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            return true;

        return false;
    }
    public static float GetHorizontalValue()
    {
        return Input.GetAxis("Horizontal");
    }

}
