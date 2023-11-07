using System;

public class Health
{
    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }

    public event Action Die;
    public event Action ValueChanged;

    public Health(float maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }
    
    public void Decrease(float value)
    {
        CurrentHealth -= value;
        ValueChanged?.Invoke();
        if (CurrentHealth <= 0)
        {
            Die?.Invoke();
        }
    }

    public void Increase()
    {
        CurrentHealth = MaxHealth;    
        ValueChanged?.Invoke();
    }
}
