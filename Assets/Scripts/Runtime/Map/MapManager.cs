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
    public GameObject[] groundPrefabs;
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

    private void Start()
    {
        InitGround();
    }

    private void Update()
    {
        foreach (GameObject ground in groundPool)
        {
            if (ground.activeSelf)
            {
                ground.transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
        }

        RecycleGround();
    }

    private void InitGround()
    {
        for (int i = 0; i < poolSize; i++)
        {
            SpawnGround();
        }
    }
    private void SpawnGround()
    {
        GameObject ground = Instantiate(groundPrefabs[Random.Range(0, groundPrefabs.Length)]);
        ground.transform.position = new Vector3(0, 0, groundSize * groundPool.Count);
        ground.SetActive(true);
        groundPool.Enqueue(ground);
    }
    private void RecycleGround()
    {
        foreach (GameObject ground in groundPool)
        {
            if (ground.transform.position.z < -groundSize)
            {
                float newZ = (groundPool.Count - 1) * groundSize;
                ground.transform.position = new Vector3(0, 0, newZ);

                if(ground.GetComponentInChildren<Ground>() != null)
                {
                    ground.GetComponentInChildren<Ground>().InitChoices();
                }
            }
        }
    }
}
