using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling
{
    public Dictionary<string, List<GameObject>> pool;

    public Pooling()
    {
        pool = new Dictionary<string, List<GameObject>>();
    }

    public GameObject GenerateFromPool(GameObject item, Transform parent)
    {
        if (pool.ContainsKey(item.name))
        {
            // if item available in pool
            if (pool[item.name].Count > 0)
            {
                GameObject newItemFromPool = pool[item.name][0];
                pool[item.name].Remove(newItemFromPool);
                newItemFromPool.SetActive(true);
                return newItemFromPool;
            }
        }
        else
        {
            // if item list not defined, create new one
            pool.Add(item.name, new List<GameObject>());
        }

        // create new one if no item available in pool
        GameObject newItem = Object.Instantiate(item, parent);
        newItem.name = item.name;
        return newItem;
    }

    public void ReturnToPool(GameObject item)
    {
        if (!pool.ContainsKey(item.name))
        {
            Debug.LogError("INVALID POOL ITEM!!");
        }

        pool[item.name].Add(item);
        item.SetActive(false);
    }
}