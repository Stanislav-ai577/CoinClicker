using System;
using TMPro;
using UnityEngine;
using YG;

public class AddCoinsWiever : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _addCoinText;
    [SerializeField] private Abilities _addCoinAbilities;

    private void Start()
    {
        YandexGame.NewLeaderboardScores("LiderBoardCatCoin", _addCoinAbilities.ValueFiftyPerSeconds + _addCoinAbilities.ValuePerSeconds);
    }
    
    private void Update()
    {
        AddCoinWiever();
    }
    
    private void AddCoinWiever()
    {
        _addCoinText.text = Math.Round(_addCoinAbilities.ValueFiftyPerSeconds + _addCoinAbilities.ValuePerSeconds).ToString();
    }
}
