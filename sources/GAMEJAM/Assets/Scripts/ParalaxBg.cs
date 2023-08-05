using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBg : MonoBehaviour
{
    [SerializeField] 
    private Transform _folowingTarget;
    
    [SerializeField, Range(0f, 1f)]
    private float _paralaxSettings = 0.1f;
    
    [SerializeField] 
    private bool _disableVerticalParalax;
    
    private Vector3 _targetPreviousPosition;


    private void Start()
    {

        if (!_folowingTarget)
        {
            _folowingTarget = Camera.main.transform;
        }

        _targetPreviousPosition = _folowingTarget.position;
    }

    private void Update()
    {
        var delta = _folowingTarget.position - _targetPreviousPosition;

        if (_disableVerticalParalax)
            delta.y = 0;

        _targetPreviousPosition = _folowingTarget.position;

        transform.position += delta * _paralaxSettings;
    }
}
