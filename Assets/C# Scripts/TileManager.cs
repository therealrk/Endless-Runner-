using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject[] secondTilePrefabs;
    public GameObject[] thirdTilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 3;
    public ScoreSystem scoreSystem;
    [SerializeField] private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTranform;
    // Start is called before the first frame update
    void Start()
    {
        playerTranform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTranform.position.z -35> zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        if (scoreSystem.distance <= 1*scoreSystem.distanceindent*scoreSystem.distances)
        {
            GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
            activeTiles.Add(go);
            zSpawn += tileLength;
            Debug.Log("HongKongPrefab");
        }
        if (scoreSystem.distance <= 2* scoreSystem.distanceindent * scoreSystem.distances && scoreSystem.distance >= 1 * scoreSystem.distanceindent * scoreSystem.distances)
        {
            GameObject go_02 = Instantiate(secondTilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
            activeTiles.Add(go_02);
            zSpawn += tileLength;
            Debug.Log("ChinaPrefab");
        }
        if (scoreSystem.distance <= 3 * scoreSystem.distanceindent * scoreSystem.distances&& scoreSystem.distance >= 2 * scoreSystem.distanceindent * scoreSystem.distances)
        {
            GameObject go_03 = Instantiate(thirdTilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
            activeTiles.Add(go_03);
            zSpawn += tileLength;
            Debug.Log("TrainStation");
        }

    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
