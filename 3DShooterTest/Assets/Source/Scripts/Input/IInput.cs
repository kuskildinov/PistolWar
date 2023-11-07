public interface IInput 
{
    float MouseHorizontalMove();
    float MouseVerticalMove();
    float HorizontalMove();
    float VerticalMove();
    bool Jump();
    bool Shoot();
    bool GunReload();
    bool TakeAim();
    bool Run();

    bool PauseButton();
}
