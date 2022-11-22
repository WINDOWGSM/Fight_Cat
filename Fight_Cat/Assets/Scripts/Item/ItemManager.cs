using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameObject[] itemPrefabs;
    [Range(2f, 5f)] [SerializeField] float spawnDelayTime;

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
        while (true)
        {

            Vector3 rand_Vec = new Vector3(Random.Range(-15, 16), Random.Range(-13, 12),0);

            Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)],rand_Vec,Quaternion.identity);

            yield return new WaitForSeconds(spawnDelayTime);

            yield return new WaitForEndOfFrame();

        }
    }
}
