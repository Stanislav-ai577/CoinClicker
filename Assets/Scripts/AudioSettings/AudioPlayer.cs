using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private TextMeshProUGUI _audioExecutor;
    [SerializeField] private TextMeshProUGUI _audioName;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Slider _audioTime;
    [SerializeField] private float _volume;
    [SerializeField] private int _indexAudio;

    private void OnValidate()
    {
        _audioSource ??= GetComponent<AudioSource>();
    }
    
    private void Awake()
    {
        _playButton.onClick.AddListener(AudioSourcePlaying);
        _nextButton.onClick.AddListener(NextTrack);
        _previousButton.onClick.AddListener(PastTrack);
        _pauseButton.onClick.AddListener(Pause);
    }

    private void Start()
    {
        AudioSourcePlaying();
    }

    private void Update()
    {
        if (_audioSource.clip != null && _audioSource.isPlaying)
            _audioTime.value += Time.deltaTime;
        else
            return;
        
        if (_audioTime.value == _audioTime.maxValue)
            NextTrack();
    }
    
    private void NextTrack()
    {
        _indexAudio++;
        if (_indexAudio > _audioClip.Count - 1)
            _indexAudio = 0;
        AudioSourcePlaying();
    }
    
    private void PastTrack()
    {
        _indexAudio--;
        if (_indexAudio < 0)
            _indexAudio = _audioClip.Count - 1;
        AudioSourcePlaying();
    }

    private void Pause()
    {
        _audioSource.Pause();
    }
    
    private void AudioSourcePlaying()
    {
        _audioSource.clip = _audioClip[_indexAudio];
        _audioSource.volume = _volume;
        _audioSource.Play(); 
        TrackName();
    }

    private void TrackName()
    {
        string[] audioName = _audioSource.clip.name.Split('-');
        _audioName.text = audioName[0];
        _audioTime.maxValue = _audioSource.clip.length;
    }
}
