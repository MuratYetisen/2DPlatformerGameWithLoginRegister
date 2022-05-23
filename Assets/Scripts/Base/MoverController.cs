using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverController : IPlayerController
{
    public float HorizontalAxis => Input.GetAxis("Horizontal") * Time.deltaTime;

    public float VerticalAxis => Input.GetAxis("Vertical") * Time.deltaTime;

    public float JumpAxis => Input.GetAxis("Jump"); 

    public void Horizontal(Transform _transform, float _playerspeed, bool _isHorizonrtalActive)
    {
        switch (_isHorizonrtalActive)
        {
            case true:
                _transform.position += new Vector3(HorizontalAxis * _playerspeed, 0);
                break;
            default:
                _isHorizonrtalActive = false;
                break;

        }
    }
    public void Vertical(Transform _transform, float _climbSpeed, bool _isVerticalActive)
    {
        switch (_isVerticalActive)
        {
            case true:
                _transform.position += new Vector3(0, VerticalAxis * _climbSpeed);
                break;
            default:
                _isVerticalActive = false;
                break;
        }
    }
    public void Jump(Rigidbody2D rigidbody2d, float _jumpforce, bool _isJumpActive)
    {
        switch (_isJumpActive)
        {
            case true:
                rigidbody2d.AddForce(Vector2.up * _jumpforce * JumpAxis);
                break;
            default:
                break;
        }



    }
    public void Flip(SpriteRenderer spriteRenderer, bool _isFlipActive)
    {
        switch (_isFlipActive)
        {
            case true:
                if (HorizontalAxis<0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (HorizontalAxis >0)
                {
                    spriteRenderer.flipX = false;
                }
                break;
            default:
                break;
        }
    }

}
