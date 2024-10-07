using System;
using UnityEngine;

public class BuyPerSeconds : BuyPerClick
{
    public Action OnUpdatePricePerSecond;
    
    private void OnValidate()
    {
        _animator ??= GetComponent<Animator>();
    }
    
    private void Awake()
    {
        _button.onClick.AddListener(ButtonAnimation);
        _button.onClick.AddListener(BuyAbilities);
    }

    protected override void BuyAbilities()
    {
        if (_wallet.TrySpend(Price))
        {
            Price *= 3f;
            OnUpdatePricePerSecond?.Invoke();
            _abilities.AddValuePerSeconds(Value);
        }
    }
}
