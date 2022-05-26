using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] float _maxDistance,_platformSpeed;
    [SerializeField] Transform _platformTransform;
    [SerializeField] Transform[] _platformEdges;
    [SerializeField] LayerMask _layermask;
    bool _isNearGround;
    public bool IsNearGround => _isNearGround;
    

   
    void Update()
    {
        foreach (Transform platformTransform in _platformEdges)
        {
            PlatformMoveControl(platformTransform);
            if (_isNearGround) break;
        }
    }
    void PlatformMoveControl(Transform platformTransform)
    {
        RaycastHit2D PlatfHit = Physics2D.Raycast(platformTransform.position, platformTransform.forward, _maxDistance,_layermask);
        Debug.DrawRay(platformTransform.position, platformTransform.forward*_maxDistance, Color.red);
        if (PlatfHit.collider!=null)
        {
            _isNearGround = true;
        }
        else
        {
            _isNearGround = false;
        }
    }
    private void FixedUpdate()
    {
        if (_isNearGround)
        {
            _platformSpeed *= -1; 
        }
        else
        {
            _platformSpeed *= +1;
        }
        PlatformMove();
    }
    void PlatformMove()
    {
        _platformTransform.position += new Vector3(10*_platformSpeed*Time.deltaTime, 0);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag=="Player")
    //    {
    //        transform.SetParent(collision.transform);
    //    }
    //}
}
