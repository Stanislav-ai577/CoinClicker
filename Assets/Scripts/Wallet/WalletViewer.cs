using System;
using TMPro;
using UnityEngine;

public class WalletViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Wallet _wallet;
    
    private void OnEnable()
    {
        _wallet.OnValueChange += UpdateView;
    }

    private void OnDisable()
    {
        _wallet.OnValueChange -= UpdateView;
    }
    
    private void UpdateView(float amount)
    {
        _counterText.text = Math.Round(amount).ToString();

        if (amount > 1000)
        {
            _counterText.text = $"{Math.Round(amount / 1000, 1).ToString()}K";
        }
    }
}
