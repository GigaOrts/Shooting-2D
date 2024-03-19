using System.Collections.Generic;
using UnityEngine;

public class Pool<Template> where Template : MonoBehaviour
{
    private readonly List<Template> _pool = new();

    private readonly Template _prefab;
    private readonly Transform _container;
    private readonly int _startAmount;

    private int PoolCount => _pool.Count;

    public Pool(Template prefab, Transform container, int startAmount)
    {
        _prefab = prefab;
        _container = container;
        _startAmount = startAmount;

        for (int i = 0; i < _startAmount; i++)
        {
            Create();
        }
    }

    public Template Peek()
    {
        if (TryGetObject(out Template template) == false)
        {
            template = Create();
        }

        template.gameObject.SetActive(true);
        return template;
    }

    private bool TryGetObject(out Template template)
    {
        template = null;

        for (int i = 0; i < PoolCount; i++)
        {
            if (_pool[i].gameObject.activeInHierarchy == false)
            {
                template = _pool[i];
                return true;
            }
        }

        return false;
    }

    private Template Create()
    {
        Template template = Object.Instantiate(_prefab, _container);
        template.gameObject.SetActive(false);
        _pool.Add(template);

        return template;
    }
}
