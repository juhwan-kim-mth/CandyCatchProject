using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CandySpawner : MonoBehaviour
{
    public static CandySpawner instance;
    
    
    [SerializeField] private float maxX;
    [SerializeField] private float spawnInterval;
    [SerializeField] GameObject[] Candies;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        //SpawnCandy();
        StartSpawnCandies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCandy()
    {
        int rand = Random.Range(0, Candies.Length);
        float randomX = Random.Range(-maxX, maxX);
        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(Candies[rand], randomPos, transform.rotation);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawnCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawnCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}
