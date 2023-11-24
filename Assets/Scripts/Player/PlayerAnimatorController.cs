using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator _animator;
    public bool _isGrounded;

    private void Awake()
    {
        PlayerAnimatorInitialisation();
    }

    private void Update()
    {
        if (!_isGrounded && _animator.GetBool("Moving"))
            _animator.SetBool("Moving", false);

        if (_isGrounded && !_animator.GetBool("Grounded"))
            _animator.SetBool("Grounded", true);
        else if (!_isGrounded && _animator.GetBool("Grounded"))
            _animator.SetBool("Grounded", false);
    }

    public void AnimatorOnMove(bool _isMoving)
    {
        _animator.SetBool("Moving", _isMoving);
    }

    public void AnimatorOnJump(bool _isJumping)
    {
        _animator.SetBool("SimpleJump", _isJumping);
    }

    public void AnimatorOnDoubleJump()
    {
        _animator.SetTrigger("DoubleJump");
    }

    public void AnimatorOnLateralAttack()
    {
        _animator.SetTrigger("LateralAttack");
    }

    public void AnimatorOnDownAttack()
    {
        _animator.SetTrigger("DownAttack");
    }

    public void AnimatorOnDefend(bool _isParrying)
    {
        _animator.SetBool("Parry", _isParrying);
    }

    public void AnimatorOnHit()
    {
        _animator.SetTrigger("Hit");
    }

    private void PlayerAnimatorInitialisation()
    {
        _animator = GetComponent<Animator>();
        _isGrounded = false;
    }
}
