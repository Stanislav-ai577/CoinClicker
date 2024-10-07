using System;
using System.Collections;
using UnityEngine;
using YG;

public class Wallet : MonoBehaviour
{
    public Action<float> OnValueChange;

    [SerializeField] private CatClick _catClick;
    [SerializeField] private Abilities _abilities;
    [field:SerializeField] public float CoinAmount { get; private set; }

    private void OnEnable()
    {
        _catClick.OnClick += Click;
    }

    private void OnDisable()
    {
        _catClick.OnClick -= Click;
    }
    
    private void Start()
    {
        StartCoroutine(SecondsTick());
        if (YandexGame.SDKEnabled == true)
        {
            CoinAmount = YandexGame.savesData.coin;
        }
    }
    
    public bool TrySpend(float spendAmount)
    {
        if (spendAmount < 0)
            throw new ArgumentException("Spend amount cannot be negative");
        if (CoinAmount < spendAmount)
        {
            return false;
        }
        else
        {
            RemoveAmount(spendAmount);
            return true;
        }
    }
    
    private void Click()
    {
        AddAmount(_abilities.ValuePerClick);
    }
    
    private void AddAmount(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative");
        CoinAmount += amount;
        OnValueChange?.Invoke(CoinAmount);
    }

    private void RemoveAmount(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative");
        CoinAmount -= amount;
        OnValueChange?.Invoke(CoinAmount);
    }

    public void AddAmountRewards(float amount)
    {
        CoinAmount += amount;
    }

    private IEnumerator SecondsTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            AddAmount(_abilities.ValuePerSeconds);
            AddAmount(_abilities.ValueFiftyPerSeconds);
        }
    }
}
