using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRoutine()
    {
        while(true) {
            Vector3 pos = new Vector3(Random.Range(-8.0f, 8.0f), 7f, 0);
            Instantiate(enemyPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
