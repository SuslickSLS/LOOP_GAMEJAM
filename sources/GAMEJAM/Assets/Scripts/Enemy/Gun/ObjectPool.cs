using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject _container;

    [SerializeField]
    private int _copasaty;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Instalize(GameObject prefab)
    {
        for (int i = 0; i < _copasaty; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(x => x.activeSelf == false);
        return result != null;
    }
}
