using System.Collections.Generic;
using UnityEngine;

public enum ObstacleKey
{
    Tree, Stone, Capsule
}

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set; }

    [Header("Map Prefabs")]
    public GameObject groundPrefab;
    public GameObject[] obstaclePrefabs;
    public Dictionary<ObstacleKey, GameObject> obstacleDictionary = new Dictionary<ObstacleKey, GameObject>();

    private Queue<GameObject> groundPool = new Queue<GameObject>();

    [Header("Map Settings")]
    public float speed = 5.0f;
    public int poolSize = 5;
    public float groundSize = 10.0f;
    public float mapWidth = 2.0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            SpawnGround(i);
        }
    }

    void Update()
    {
        foreach (GameObject ground in groundPool)
        {
            ground.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (groundPool.Peek().transform.position.z < -groundSize)
        {
            RepositionGround();
        }
    }

    private void InitObstacleDictionary()
    {
        for (int i = 0; i < obstaclePrefabs.Length; i++)
        {
            ObstacleKey key = (ObstacleKey)i;
            obstacleDictionary[key] = obstaclePrefabs[i];
        }
    }

    private void SpawnGround(int n)
    {
        GameObject ground = Instantiate(groundPrefab, new Vector3(0, 0, n * groundSize), Quaternion.identity);
        ground.SetActive(true);
        groundPool.Enqueue(ground);
    }

    private void RepositionGround()
    {
        GameObject oldGround = groundPool.Dequeue();
            float newZ = (poolSize - 1) * groundSize + groundPool.Peek().transform.position.z;
            oldGround.transform.position = new Vector3(0, 0, newZ);
            groundPool.Enqueue(oldGround);
    }
}
