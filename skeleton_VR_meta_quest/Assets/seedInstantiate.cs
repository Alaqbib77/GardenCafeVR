using UnityEngine;

public class SeedSack : MonoBehaviour
{
    public GameObject seedPrefab;
    public Transform spawnPoint;

    public void GiveSeed()
    {
        Instantiate(seedPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}