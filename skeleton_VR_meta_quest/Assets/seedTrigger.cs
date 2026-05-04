using UnityEngine;

public class PlantSpot : MonoBehaviour
{
    public GameObject mangoPrefab;
    public Transform spawnPoint;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("seed"))
        {
            Debug.Log("Seed planted!");

            // spawn mango
            Instantiate(mangoPrefab, spawnPoint.position, spawnPoint.rotation);

            // delete the seed
            Destroy(collision.gameObject);
        }
    }
}