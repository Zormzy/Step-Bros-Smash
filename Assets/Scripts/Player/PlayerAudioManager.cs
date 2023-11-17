using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [Header("Attack SFX")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _attackSFX;
    [SerializeField] private AudioClip _jumpSFX;
    [SerializeField] private AudioClip _doubleJumpSFX;

    public void AudioSFXOnAttack()
    {
        _audioSource.clip = _attackSFX;
        _audioSource.volume = 1f;
        _audioSource.Play();
    }

    public void AudioSFXOnJump()
    {
        _audioSource.clip = _jumpSFX;
        _audioSource.volume = 1f;
        _audioSource.Play();
    }

    public void AudioSFXOnDoubleJump()
    {
        _audioSource.clip = _doubleJumpSFX;
        _audioSource.volume = 1f;
        _audioSource.Play();
    }
}
