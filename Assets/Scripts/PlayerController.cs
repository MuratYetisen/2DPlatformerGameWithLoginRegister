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
    [SerializeField] float _playerSpeed,_jumpForce;
    [SerializeField] bool _isHorizontalActive, _isJumpActive,_isFlipActive;
    [SerializeField] Rigidbody2D _playerRigidbody2D;
    [SerializeField] SpriteRenderer _spriteRenderer;
/*  [SerializeField]*/  bool _isSpaceControl;
    [SerializeField] Animator _animator;
    
    private void Awake()
    {
        _moverController = new MoverController();
        _onGroundCheck = new OnGroundCheck();
        
    }
    

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _isSpaceControl = true;
        }
       
    }
    private void FixedUpdate()
    {
        Walk();
        Jump();
        Flip();
       
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
        //if (_onGroundCheck.IsOnGround == false)
        //{
        //    _isSpaceControl = false;
        //}

    }
    void Flip()
    {
        _moverController.Flip(_spriteRenderer, _isFlipActive);
    }
    void Climb()
    {

    }

}
