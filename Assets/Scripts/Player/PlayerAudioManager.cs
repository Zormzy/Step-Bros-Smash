using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [Header("Attack SFX")]
    [SerializeField] private AudioSource _audioSourceAttack;
    [SerializeField] private AudioSource _audioSourceJump;
    [SerializeField] private AudioClip _attackSFX;
    [SerializeField] private AudioClip _jumpSFX;
    [SerializeField] private AudioClip _doubleJumpSFX;

    public void AudioSFXOnAttack()
    {
        _audioSourceJump.clip = _attackSFX;
        _audioSourceJump.volume = 1f;
        _audioSourceJump.Play();
    }

    public void AudioSFXOnJump()
    {
        _audioSourceJump.clip = _jumpSFX;
        _audioSourceJump.volume = 1f;
        _audioSourceJump.Play();
    }

    public void AudioSFXOnDoubleJump()
    {
        _audioSourceJump.clip = _doubleJumpSFX;
        _audioSourceJump.volume = 1f;
        _audioSourceJump.Play();
    }
}
