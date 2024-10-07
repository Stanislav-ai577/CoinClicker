using System;
using UnityEngine;

public class BuyFiftyPerSeconds : BuyPerClick
{
    public Action OnUpdatePriceFiftyPerSecond;
    
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
            Price *= 4f;
            OnUpdatePriceFiftyPerSecond?.Invoke();
            _abilities.AddValueFiftyPerSeconds(Value);
        }
    }
}
