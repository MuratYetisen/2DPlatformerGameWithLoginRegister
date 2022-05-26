using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    MoverController _moverController;
    OnGroundCheck _onGroundCheck;
    [SerializeField] Transform _PlayerTransform;
    [SerializeField] float _playerSpeed,_jumpForce,_climbSpeed;
    [SerializeField] bool _isHorizontalActive, _isJumpActive,_isFlipActive, _isVerticalActive;
    [SerializeField] Rigidbody2D _playerRigidbody2D;
    [SerializeField] SpriteRenderer _spriteRenderer;
                    public bool _isSpaceControl, _isOnLedder;
    [SerializeField] Animator _animator;
    
    private void Awake()
    {
        _moverController = new MoverController();
        _onGroundCheck = GetComponent<OnGroundCheck>();
        
    }
    

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _isSpaceControl = true;
        }
        if (!_onGroundCheck.IsOnGround)
        {
            _isSpaceControl = false;
            _animator.SetBool("__isJump", false);

        }

    }
    private void FixedUpdate()
    {
        Walk();
        Jump();
        Flip();
        Climb();
    }
    void Walk()
    {
        _moverController.Horizontal(_PlayerTransform, _playerSpeed, _isHorizontalActive);
        _animator.SetFloat("__isWalk", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
    void Jump()
    {
        if (_isSpaceControl)
        {
            _moverController.Jump(_playerRigidbody2D, _jumpForce, _isJumpActive);
            _animator.SetBool("__isJump", _isSpaceControl);
        }
    


    }
    void Flip()
    {
        _moverController.Flip(_spriteRenderer, _isFlipActive);
    }
    void Climb()
    {
        if (_isOnLedder)
        {
            _moverController.Vertical(_PlayerTransform, _climbSpeed, _isVerticalActive);
            _animator.SetBool("__onLedder", true);
        }
        
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Platform")
    //    {
    //        transform.SetParent(collision.transform);
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Platform")
    //    {
    //        transform.SetParent(GetComponent("Player").transform);
    //    }
    //}
}
