using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> NPCSpawns;
    [SerializeField] private List<GameObject> NPCList;
    [SerializeField] private GameObject NPCPrefab;

    private int totalSpawnCounts = 3;
    private bool isGameOver;
    private float spawnDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNPC());
    }

    private IEnumerator SpawnNPC()
    {
        if (!isGameOver) 
        {
            for (int i = 0; i < totalSpawnCounts; i++)
            {
                GameObject NPC = Instantiate(NPCPrefab, NPCSpawns[Random.Range(0, NPCSpawns.Count)].transform.position, Quaternion.identity);
                NPCList.Add(NPC);
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
