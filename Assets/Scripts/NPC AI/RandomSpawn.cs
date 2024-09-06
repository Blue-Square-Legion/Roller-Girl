using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> NPCSpawns;
    [SerializeField] private List<GameObject> NPCList;
    [SerializeField] private GameObject NPCPrefab;
    public static float z;
   [SerializeField] public int totalSpawnCounts = 1;
    private bool isGameOver;
    private float spawnDelay = 0.5f;
    public TextMeshProUGUI NPCText;
    [SerializeField] public static int copySpawn;
    // Start is called before the first frame update
    void Start()
    {   z= totalSpawnCounts;
        copySpawn = totalSpawnCounts;
        StartCoroutine(SpawnNPC());
    }

    private IEnumerator SpawnNPC()
    {
        if (!isGameOver)
        {
            int index;
            int[] usedindices = new int[totalSpawnCounts];
            for (int i = 0; i < totalSpawnCounts; i++)
            {
                do
                {
                    index = Random.Range(0, NPCSpawns.Count);
                    //   Debug.Log($"Can you see mee: {index}");
                } while (usedindices.Contains(index));
                usedindices[i] = index;
                GameObject NPC = Instantiate(NPCPrefab, NPCSpawns[index].transform.position, Quaternion.identity);
                NPCList.Add(NPC);
            }
            foreach (var item in usedindices)
            {
                //  Debug.Log(item);
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }
    private void Update()
    {
        NPCText.text = z.ToString() + " : NPCs";
    }
}
