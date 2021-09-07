using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTileSystem;
    Vector3 nextSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnNextTile();
        }
    }

    public void SpawnNextTile()
    {
        GameObject temp = Instantiate(groundTileSystem, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

  }
