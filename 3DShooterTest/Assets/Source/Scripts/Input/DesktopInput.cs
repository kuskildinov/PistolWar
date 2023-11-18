using UnityEngine;

public class DesktopInput : IInput
{
    private const string MouseHorizontal = "Mouse X";
    private const string MouseVertical = "Mouse Y";
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    public float HorizontalMove()
    {
        return Input.GetAxis(HorizontalAxis);
    }
    public float VerticalMove()
    {
        return Input.GetAxis(VerticalAxis);
    }

    public bool Jump()
    {
        return Input.GetKey(KeyCode.Space);
    }

    public bool Run()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    public float MouseHorizontalMove()
    {
        return Input.GetAxis(MouseHorizontal);
    }

    public float MouseVerticalMove()
    {
        return Input.GetAxis(MouseVertical);
    }

    public bool Shoot()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool GunReload()
    {
        return Input.GetKey(KeyCode.R);
    }

    public bool TakeAim()
    {
        return Input.GetMouseButton(1); 
    }

    public bool PauseButton()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }


}
