using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class YaAdvertisement : MonoBehaviour
{
    [SerializeField] private Button _buttonHundred;
    [SerializeField] private Button _buttonFifty;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameObject _rewardWindow;
    private Coroutine _coroutineAdvertisement;
    private Coroutine _coroutineReward;

    private void Awake()
    {
        _rewardWindow.SetActive(false);
    }
    
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }
    
    private void Start()
    {
        _coroutineAdvertisement = StartCoroutine(AdvertisementTick());
        _coroutineReward = StartCoroutine(ShowRewardWindowTick());
        
        
        _buttonFifty.onClick.AddListener(delegate {ExampleOpenRewards(1); });
        _buttonHundred.onClick.AddListener(delegate {ExampleOpenRewards(2); });
    }

    private void Rewarded(int id)
    {
        if (id == 1)
            _wallet.AddAmountRewards(50f);
        else if (id == 2)
            _wallet.AddAmountRewards(100f);
        
        _rewardWindow.SetActive(false);
    }
    
    private void ExampleOpenRewards(int id)
    {
        YandexGame.RewVideoShow(id);
    }
    
    private IEnumerator AdvertisementTick()
    {
        yield return new WaitForSecondsRealtime(10f);
        YandexGame.FullscreenShow();
    }
    
    private IEnumerator ShowRewardWindowTick()
    {
        yield return new WaitForSecondsRealtime(20f);
        _rewardWindow.SetActive(true);
    }
    
}
