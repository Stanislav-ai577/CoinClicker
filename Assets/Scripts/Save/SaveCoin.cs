using System.Collections;
using UnityEngine;
using YG;

public class SaveCoin : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _currentCoin;

    private void Start()
    {
        StartCoroutine(SaveTick());
    }

    private void SaveCoins()
    {
        _currentCoin = _wallet.CoinAmount;
        YandexGame.savesData.coin = _currentCoin;
        YandexGame.SaveProgress();
    }

    private IEnumerator SaveTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            SaveCoins();
        }
    }
}
