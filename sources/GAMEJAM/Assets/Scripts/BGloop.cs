using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGloop : MonoBehaviour
{
    [SerializeField]
    private Transform _cameraTransform;
    [SerializeField]
    private float _vievZone = 5f;
    [SerializeField]
    private float _backgroudSize = 41f;
    [SerializeField]
    private float _parralaxSpeed = 0.3f;


    private Transform[] _layers;
    private int _leftIndex;
    private int _rightIndex;
    private float _lastCameraX;

    private void Start()
    {
        _lastCameraX = _cameraTransform.position.x;
        _layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _layers[i] = transform.GetChild(i);
            _leftIndex = 0;
            _rightIndex = _layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        float lastLeft = _leftIndex;
        _layers[_leftIndex].position = Vector3.right * (_layers[_rightIndex].position.x + _backgroudSize);
        _rightIndex = _leftIndex;
        _leftIndex++;

        if(_leftIndex == _layers.Length)
        {
            _leftIndex = 0;
        }
    }

    private void ScrollLeft()
    {
        float lastIndex = _rightIndex;
        _layers[_rightIndex].position = Vector3.right * (_layers[_leftIndex].position.x + _backgroudSize);
        _leftIndex = _rightIndex;
        _rightIndex--;

        if (_rightIndex < 0)
        {
            _rightIndex = _layers.Length - 1;
        }
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x, _cameraTransform.position.y);
        _layers[_leftIndex].transform.position = new Vector2(transform.position.x, _cameraTransform.position.y);
        _layers[_rightIndex].transform.position = new Vector2(transform.position.x, _cameraTransform.position.y);

        float deltaX = _cameraTransform.position.x - _lastCameraX;
        _lastCameraX = _cameraTransform.position.x;
        transform.position += Vector3.right * (deltaX * _parralaxSpeed);

        if (_cameraTransform.position.x < _layers[_leftIndex].transform.position.x + _vievZone)
        {
            ScrollLeft();
        }

        if (_cameraTransform.position.x > _layers[_rightIndex].transform.position.x - _vievZone)
        {
            ScrollRight();
        }
    }

}
