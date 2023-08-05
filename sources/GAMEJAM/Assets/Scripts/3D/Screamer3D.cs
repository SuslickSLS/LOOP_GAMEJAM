using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer3D : MonoBehaviour
{
    [SerializeField]
    private GameObject _scereamer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            StartCoroutine(SreammerCoroutine());
        }
    }


    private IEnumerator SreammerCoroutine()
    {
        _scereamer.SetActive(true);

        yield return new WaitForSeconds(2);

        _scereamer.SetActive(false);
    }
}
