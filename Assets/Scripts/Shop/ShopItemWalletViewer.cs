using System;
using TMPro;
using UnityEngine;
using YG;

public class ShopItemWalletViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pricePerCLick;
    [SerializeField] private TextMeshProUGUI _pricePerSeconds;
    [SerializeField] private TextMeshProUGUI _priceHighPerSeconds;
    
    [SerializeField] private BuyPerClick _buyPerClick;
    [SerializeField] private BuyPerSeconds _buyPerSeconds;
    [SerializeField] private BuyFiftyPerSeconds _buyFiftyPerSeconds;
    
    private void Start()
    {
        UpdateInfoPerClick();
        UpdateInfoPerSeconds();
        UpdateInfoFifrtyPerClick();
    }
    
    private void OnEnable()
    {
        _buyPerClick.OnUpdatePricePerClick += UpdateInfoPerClick;
        _buyPerSeconds.OnUpdatePricePerSecond += UpdateInfoPerSeconds;
        _buyFiftyPerSeconds.OnUpdatePriceFiftyPerSecond += UpdateInfoFifrtyPerClick;
    }

    private void OnDisable()
    {
        _buyPerClick.OnUpdatePricePerClick -= UpdateInfoPerClick;
        _buyPerSeconds.OnUpdatePricePerSecond -= UpdateInfoPerSeconds;
        _buyFiftyPerSeconds.OnUpdatePriceFiftyPerSecond -= UpdateInfoFifrtyPerClick;
    }
    
    private void UpdateInfoPerClick()
    {
        _pricePerCLick.text = Math.Round(_buyPerClick.Price, 1).ToString();
    }

    private void UpdateInfoPerSeconds()
    {
        _pricePerSeconds.text = Math.Round(_buyPerSeconds.Price, 1).ToString();
    }

    private void UpdateInfoFifrtyPerClick()
    {
        _priceHighPerSeconds.text = Math.Round(_buyFiftyPerSeconds.Price, 1).ToString();
    }
}
