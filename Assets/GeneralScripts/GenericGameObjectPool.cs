using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericGameObjectPool : MonoBehaviour
{
    public GameObject instanceObj;
    public List<GameObject> instanceCollection = null;

    public T UnpoolItem<T>() where T : Component
    {
        if (instanceObj.GetComponent<T>() == null) return null;
        if (instanceCollection == null) instanceCollection = new List<GameObject>(1);

        GameObject item;
        if (instanceCollection.Count > 0) {
            item = instanceCollection[0];
            instanceCollection.RemoveAt(0);
        } else {
            item = Instantiate<GameObject>(instanceObj);
        }

        item.SetActive(true);
        return item.GetComponent<T>();
    }

    public void PoolItem<T>(T item) where T : Component {
        if (instanceCollection == null) instanceCollection = new List<GameObject>(1);
        instanceCollection.Add(item.gameObject);
    }
}
