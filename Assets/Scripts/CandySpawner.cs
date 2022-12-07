using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class CandySpawner : MonoBehaviour
{
    public static CandySpawner Instance;


    [FormerlySerializedAs("maxX")] [SerializeField]
    float _maxX;

    [FormerlySerializedAs("spawnInterval")] [SerializeField]
    float _spawnInterval;

    [FormerlySerializedAs("Candies")] [SerializeField]
    GameObject[] _candies;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        StartSpawnCandies();
    }


    void SpawnCandy()
    {
        var rand = Random.Range(0, _candies.Length);
        var randomX = Random.Range(-_maxX, _maxX);
        var transform1 = transform;
        var position = transform1.position;
        var randomPos = new Vector3(randomX, position.y, position.z);
        Instantiate(_candies[rand], randomPos, transform1.rotation);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(_spawnInterval);
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