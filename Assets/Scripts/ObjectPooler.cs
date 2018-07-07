using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [HideInInspector]
    public static ObjectPooler Current;
    public GameObject BulletPrefab;
    public int PooledAmount = 10;
    [Tooltip("Will the pool grow automatically when there are no objects left in it")]
    public bool WillGrow = true;

    private List<GameObject> bulletObjects;

    private void Awake()
    {
        Current = this;
    }

    private void Start()
    {
        this.bulletObjects = new List<GameObject>();
        for (int i = 0; i < this.PooledAmount; i++)
        {
            this.bulletObjects.Add(this.CreateNewPooledObject());
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < this.bulletObjects.Count; i++)
        {
            if (this.bulletObjects[i].activeInHierarchy == false)
            {
                return this.bulletObjects[i];
            }
        }

        if (this.WillGrow)
        {
            GameObject obj = this.CreateNewPooledObject();

            this.bulletObjects.Add(obj);
            return obj;
        }

        return null;
    }

    private GameObject CreateNewPooledObject()
    {
        GameObject laser = Instantiate(this.BulletPrefab, this.transform) as GameObject;
        laser.SetActive(false);
        return laser;
    }
}
