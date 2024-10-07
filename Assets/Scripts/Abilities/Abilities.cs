using System;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [field: SerializeField] public float ValuePerClick { get; private set; }
    [field: SerializeField] public float ValuePerSeconds { get; private set; }
    [field: SerializeField] public float ValueFiftyPerSeconds { get; private set; }

    public void AddValuePerClick(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value cannot be negative.");
        ValuePerClick += amount;
    }
    
    public void AddValuePerSeconds(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value cannot be negative.");
        ValuePerSeconds += amount;
    }
    
    public void AddValueFiftyPerSeconds(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value cannot be negative.");
        ValueFiftyPerSeconds += amount;
    }
}
