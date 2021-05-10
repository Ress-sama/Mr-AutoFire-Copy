using UnityEngine;

public class KeyboardInputs : MonoBehaviour
{
    DynamicJoystick dynamicJoystick;

    private void Awake()
    {
        dynamicJoystick = FindObjectOfType<DynamicJoystick>();
    }

    void Update()
    {
        //keyboard inputs
        if (Input.GetKey(KeyCode.A))
        {
            GameInputs.Left = true;
        }
        else
        {
            GameInputs.Left = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            GameInputs.Right = true;
        }
        else
        {
            GameInputs.Right = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameInputs.Jump = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameInputs.Jump = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GameInputs.Down = true;
        }
        else
        {
            GameInputs.Down = false;
        }
        //Joystick
        if (dynamicJoystick.Vertical < -0.5f)
        {
            GameInputs.Down = true;
        }
        if (dynamicJoystick.Horizontal > 0.3f)
        {
            GameInputs.Right = true;
            GameInputs.Left = false;
        }
        else if (dynamicJoystick.Horizontal < -0.3f)
        {
            GameInputs.Left = true;
            GameInputs.Right = false;

        }
        if (dynamicJoystick.Horizontal == 0)
        {
            GameInputs.Left = false;
            GameInputs.Right = false;
        }
        if (dynamicJoystick.Vertical == 0)
        {
            GameInputs.Down = false;
        }
    }

    public void JumpDown()
    {
        GameInputs.Jump = true;
    }
    public void JumpUp()
    {
        GameInputs.Jump = false;
    }
}
