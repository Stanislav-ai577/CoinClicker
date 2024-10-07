using System;
using DG.Tweening;
using UnityEngine;

public class CatClick : MonoBehaviour
{
    public Action OnClick;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volume;
    
    private void OnMouseDown()
    {
        OnClick?.Invoke();
        
        transform.DOScale(2.8f, 0.3f).OnComplete(() =>
        {
            transform.DOScale(3f, 0.5f);
        });
        _audioSource.Play();
        _audioSource.volume = _volume;
    }
}
