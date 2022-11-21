using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameObject[] itemPrefabs;

    [SerializeField] float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnItem()
    {
        float timer = 0f;

        while (true)
        {

            Vector3 rand_Vec = new Vector3(Random.Range(-15, 16), Random.Range(-10, 10),0);

            Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)],rand_Vec,Quaternion.identity);


            yield return new WaitForEndOfFrame();

        }
    }
}
