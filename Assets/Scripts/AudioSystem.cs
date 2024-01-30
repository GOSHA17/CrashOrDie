using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSystem : MonoBehaviour
{
    [SerializeField] private AudioClip _lvlUpSound;
    [SerializeField] private AudioClip _healSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _walkSound;
    [SerializeField] private AudioClip _attackSound;

    private HealthSystem _healthSystem;
    private IMovable _moveSystem;
    private LVLSystem _lvlSystem;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _healthSystem = GetComponent<HealthSystem>();
        _lvlSystem = GetComponent<LVLSystem>();
        _moveSystem = GetComponent<IMovable>();
    }

    private void Start()
    {
        if (_lvlSystem) _lvlSystem.LVLIncreased += PlayLvlUpSound;
        if (_healthSystem)
        {
            _healthSystem.Hitted += PlayHitSound;
            _healthSystem.Healed += PlayHealSound;
            _healthSystem.Died += PlayDeathSound;
        }
    }

    private void Update()
    {
        if (_moveSystem == null) return;

        if (_moveSystem.IsMoving())
        {
            if (!_audioSource.isPlaying)
                PlayWalkSound();
        }
        else
        {
            if (_audioSource.clip == _walkSound)
                _audioSource.Stop();
        }
    }

    private void PlayLvlUpSound()
    {
        _audioSource.clip = _lvlUpSound;
        _audioSource.loop = false;
        _audioSource.Play();
    }

    private void PlayHitSound()
    {
        _audioSource.clip = _hitSound;
        _audioSource.loop = false;
        _audioSource.Play();
    }

    private void PlayHealSound()
    {
        _audioSource.clip = _healSound;
        _audioSource.loop = false;
        _audioSource.Play();
    }

    private void PlayDeathSound()
    {
        _audioSource.clip = _deathSound;
        _audioSource.loop = false;
        _audioSource.Play();
    }

    private void PlayWalkSound()
    {
        _audioSource.clip = _walkSound;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    private void OnDestroy()
    {
        if (_lvlSystem) _lvlSystem.LVLIncreased -= PlayLvlUpSound;
        if (_healthSystem)
        {
            _healthSystem.Hitted -= PlayHitSound;
            _healthSystem.Healed -= PlayHealSound;
            _healthSystem.Died -= PlayDeathSound;
        }
    }
}
