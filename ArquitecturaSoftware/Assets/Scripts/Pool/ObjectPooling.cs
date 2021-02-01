using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //Varibles necesarias para la creacion de las 
    //diversas pools.
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    //Establecimiento del singleton que nos permitira 
    //llamar este script y hacer la pool de objetos.
    #region Singleton

    public static ObjectPooling call;

    private void Awake()
    {
        call = this;
    }

    #endregion

    //Creacion de la lista y el diccionario de la pool.
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDict;

    // Start is called before the first frame update
    //Durante el start se detectan los objetos que se tienen que
    //instanciar de las diversas pools y dejarlos desactivados hasta que sea necesario. 
    void Start()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDict.Add(pool.tag, objectPool);

        }

    }
    //Aqui sea activa el objeto y se establece el spawner en el que tendremos que establecer el tag y la posicion del objeto
    //adema de detectar si el objeto que deseamos instaciar tiene el tag correctamente escrito.
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion Rotaion)
    {
        if (!poolDict.ContainsKey(tag))
        {
            Debug.LogWarning("Pool With Tag" + tag + "dont exist");
            return null;
        }

        GameObject objectToSpawn = poolDict[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = Rotaion;

        poolDict[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }




}
