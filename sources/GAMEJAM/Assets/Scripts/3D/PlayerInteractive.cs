using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _maxDistantion;

    [SerializeField]
    private GameObject _hintUI;

    [SerializeField]
    private Pause _pause;

    private Ray _ray;
    private RaycastHit _raycastHit;

    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        Ray();
        DrayRay();
        Interactive();
    }

    private void Ray()
    {
        _ray = _camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void DrayRay()
    {
        if(Physics.Raycast(_ray,out _raycastHit, _maxDistantion))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistantion, Color.blue);
        }

        if (_raycastHit.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistantion, Color.red);
        }
    }

    private void Interactive()
    {
        if (Physics.Raycast(_ray, out _raycastHit, _maxDistantion) && !_pause.IsPause())
        {
            if (_raycastHit.transform.TryGetComponent<HintScript>(out HintScript hint))
            {
                _hintUI.SetActive(true);

                hint.Hint();
            }
            else
            {
                _hintUI.SetActive(false);
            }

            if (_raycastHit.transform.CompareTag("Door"))
            {
                Debug.DrawRay(_ray.origin, _ray.direction * _maxDistantion, Color.green);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Открыть");
                    _raycastHit.transform.GetComponent<Door>().Open();
                }
            }

            if(_raycastHit.transform.CompareTag("Object"))
            {
                Debug.DrawRay(_ray.origin, _ray.direction * _maxDistantion, Color.green);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("Осмотр");
                    _raycastHit.transform.GetComponent<Inspection>().Talk();
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Подобрать");
                    _raycastHit.transform.GetComponent<TakeObject>().Take();
                }
            }
            
        }
        else
        {
            _hintUI.SetActive(false);
        }



    }

}
