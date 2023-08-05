using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject
{
    [SerializeField]
    private Vector3 _positionPlayer;
    public Vector3 PositionPlayer
    {
        get
        {
            return _positionPlayer;
        }
        set
        {
            _positionPlayer = value;
        }
    }

}
