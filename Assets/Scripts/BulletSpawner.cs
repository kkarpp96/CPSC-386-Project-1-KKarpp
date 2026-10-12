using UnityEngine;
using System.Collections.Generic;
using System.Threading;

public class BulletSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 3;
    private List<GameObject> pool = new List<GameObject>();

    private float timer = 0f;

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
        GetFromPool();
    }

    public GameObject GetFromPool()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            GetFromPool();
            timer = 0f;
        }
    }
}
