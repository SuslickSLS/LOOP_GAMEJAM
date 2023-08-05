using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private PlayableDirector _director;

    [SerializeField]
    private Vector3 _position;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.transform.position = _position;
            this.transform.localEulerAngles = new Vector3(0, -90, 0);
            StartCoroutine(DeathCoroutine());
            _player.SetActive(false);
        }
    }

    private IEnumerator DeathCoroutine()
    {
        _director.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
