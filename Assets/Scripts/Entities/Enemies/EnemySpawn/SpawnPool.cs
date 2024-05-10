using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnPool : MonoBehaviour
{
    public List<PoolableEnemies> poolList = new List<PoolableEnemies>();
    public GameObject[] enemiesToPool;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            UpdatePool(0, 5, "TestEnemy");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            UpdatePool(0, 8, "TestEnemy");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            UpdatePool(1, 4, "TestEnemy2");
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            UpdatePool(1, 7, "TestEnemy2");
        }
    }

    public void UpdatePool(int enemyIndex, int amountToPool, string enemyName)
    {
        if (poolList.Count > 0)
        {
            for (int i = 0; i < poolList.Count; i++)
            {
                if (poolList[i].listName == enemyName)
                {
                    int alreadyPooled = 0;

                    for (int x = 0; x < poolList[i].pooledEnemies.Count; x++)
                    {
                        if (poolList[i].pooledEnemies[x].name == enemyName)
                        {
                            alreadyPooled++;
                        }
                    }

                    GameObject tmp;
                    for (int a = 0; a < amountToPool - alreadyPooled; a++)
                    {
                        tmp = Instantiate(enemiesToPool[enemyIndex]);
                        tmp.name = enemyName;
                        tmp.SetActive(false);
                        poolList[i].pooledEnemies.Add(tmp);
                    }
                }
                else if (i == poolList.Count - 1 && poolList[i].listName != enemyName)
                {
                    poolList.Add(new PoolableEnemies());
                    poolList[i + 1].listName = enemyName;

                    GameObject tmp;
                    for (int z = 0; z < amountToPool; z++)
                    {
                        tmp = Instantiate(enemiesToPool[enemyIndex]);
                        tmp.name = enemyName;
                        tmp.SetActive(false);
                        poolList[i + 1].pooledEnemies.Add(tmp);
                    }
                }
            }
        }
        else
        {
            poolList.Add(new PoolableEnemies());
            poolList[0].listName = enemyName;

            GameObject tmp;
            for (int z = 0; z < amountToPool; z++)
            {
                tmp = Instantiate(enemiesToPool[enemyIndex]);
                tmp.name = enemyName;
                tmp.SetActive(false);
                poolList[0].pooledEnemies.Add(tmp);
            }
        }
    }

    public GameObject GetPooledObject(string enemyName)
    {
        for (int i = 0; i < poolList.Count; i++)
        {
            if (poolList[i].listName == enemyName)
            {
                for (int x = 0; x < poolList[i].pooledEnemies.Count; x++)
                {
                    if (!poolList[i].pooledEnemies[x].activeInHierarchy)
                    {
                        return poolList[i].pooledEnemies[x];
                    }
                }
            }
            else
            {
                continue;
            }
        }

        return null;
    }
}

[System.Serializable]
public class PoolableEnemies
{
    public string listName;
    public List<GameObject> pooledEnemies = new List<GameObject>();
}
