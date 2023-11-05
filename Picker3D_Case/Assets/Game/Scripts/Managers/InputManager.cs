using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class InputManager : MonoBehaviour
    {
        private static float horizontalValue;
        private static float lastMousePosition;
        public static bool IsMousePressed()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                return true;

            return false;
        }
        public static float GetHorizontalValue()
        {
            
            if(Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Input.mousePosition.x;
            }
            else if(Input.GetMouseButton(0))
            {
                horizontalValue = (Input.mousePosition.x - lastMousePosition) * Time.deltaTime;

                if(horizontalValue > 1.0f)
                    horizontalValue = 1.0f;
                else if(horizontalValue < -1.0f)
                    horizontalValue = -1.0f;

                lastMousePosition = Input.mousePosition.x;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                horizontalValue = 0.0f;
            }
            return horizontalValue;

        }

    }
}