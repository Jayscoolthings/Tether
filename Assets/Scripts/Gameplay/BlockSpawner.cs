using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] spawnPoints;
    [SerializeField] public GameObject block;
    GameObject randomSpawn;
    GameObject blockStorage;
    GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        blockStorage = GameObject.Find("Blocks");
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator spawnRandomBlock()
    {
            yield return new WaitForSeconds(1f);
            randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(block, randomSpawn.transform.position, Quaternion.identity, blockStorage.transform);
            StartCoroutine(spawnRandomBlock());
    }
}
