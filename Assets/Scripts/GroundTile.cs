using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawn;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawn = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnCoins();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawn.SpawnNextTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        int obstSpawnIndex = Random.Range(2, 5);
        Transform spawnpoint = transform.GetChild(obstSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnpoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;

    void SpawnCoins()
    {
        int amountOfCoins = 10;
        for (int i = 0; i < amountOfCoins; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = CoinSpawnPoint(GetComponent<Collider>());
        }
    }
    Vector3 CoinSpawnPoint(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = CoinSpawnPoint(collider);
        }
        point.y = 1;
        return point;
    }
}
