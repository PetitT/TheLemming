using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DecorPool : MonoBehaviour
{
    public static DecorPool instance;

    public List<GameObject> decorPool = new List<GameObject>();
    public List<GameObject> obstaclePool = new List<GameObject>();
    public List<GameObject> niceParticlePool = new List<GameObject>();
    public List<GameObject> wrongParticlePool = new List<GameObject>();

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        foreach (var item in DecorManager.instance.decorList)
        {
            decorPool.Add(item);
        }

        foreach (var item in DecorManager.instance.obstacleList)
        {
            obstaclePool.Add(item);
        }
    }

    public GameObject GetObjectFromPool(List<GameObject> listToPool, GameObject obj, string name, Vector2 position)
    {
        GameObject pooledObject = listToPool.Where(x => x.GetComponent<PoolTag>().poolName + " (UnityEngine.GameObject)" == name && !x.activeSelf).FirstOrDefault();

        if (!pooledObject)
        {
            pooledObject = Instantiate(obj);
            listToPool.Add(pooledObject);
        }
        pooledObject.transform.position = position;
        pooledObject.SetActive(true);

        return pooledObject;
    }

    public GameObject GetParticle(List<GameObject> pool, Vector2 position)
    {
        GameObject newParticle = pool.Where(x => !x.activeSelf).FirstOrDefault();

        if (!newParticle)
        {
            newParticle = Instantiate(pool[0]);
            pool.Add(newParticle);
        }

        newParticle.transform.position = position;
        newParticle.SetActive(true);

        return newParticle;
    }
}
