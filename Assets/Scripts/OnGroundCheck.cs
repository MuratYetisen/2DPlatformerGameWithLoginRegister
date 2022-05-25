using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundCheck : MonoBehaviour
{
    [SerializeField]
    Transform[] _translates;//Sprite �n ayaklar�n�n hepsini bir yerde toplamam�z gerekti�i i�in burada dizi belirledik.
    [SerializeField] bool _isOnGround;
    public bool IsOnGround => _isOnGround;
    [SerializeField] float _maxDistance;
    [SerializeField] LayerMask _layerMask;
   


    void Update()
    {
        
        foreach (Transform footTransform in _translates)
        {
            CheckFootOnGround(footTransform);
            if (_isOnGround) break;

        }
    }
    void CheckFootOnGround(Transform footTransform)
    {

        RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, _maxDistance, _layerMask);
        Debug.DrawRay(footTransform.position, footTransform.forward * _maxDistance, Color.red);
        if (hit.collider != null)
        {
            _isOnGround = true;
        }
        else
        {
            _isOnGround = false;
        }
    }
   
}
