using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class BuyPerClick : MonoBehaviour
{
    public Action OnUpdatePricePerClick;
    
    [SerializeField] private protected Abilities _abilities;
    [SerializeField] private protected Wallet _wallet;
    [SerializeField] private protected Button _button;
    [SerializeField] private protected Animator _animator;

    [field: SerializeField] public float Price { get; protected internal set; }
    [field: SerializeField] public float Value { get; private protected set; }

    private readonly int _click = Animator.StringToHash("Click");
    
    private void OnValidate()
    {
        _animator ??= GetComponent<Animator>();
    }

    private void Awake()
    {
        _button.onClick.AddListener(BuyAbilities);
        _button.onClick.AddListener(ButtonAnimation);
    }

    protected virtual void BuyAbilities()
    {
        if (_wallet.TrySpend(Price))
        {
            Price *= 2f;
            OnUpdatePricePerClick?.Invoke();
            _abilities.AddValuePerClick(Value);
        }
    }
    
    protected void ButtonAnimation()
    {
        _animator.SetTrigger(_click);
    }
}
