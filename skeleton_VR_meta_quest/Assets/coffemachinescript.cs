using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    public GameObject coffeePrefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mango"))
        {
            MakeCoffee(new Vector3(1.872f, 4.271f, 19.166f));
            Destroy(other.gameObject);
        }
    }

    void MakeCoffee(Vector3 position)
    {
        Debug.Log("Making coffee...");

        // spawn coffee in cup position
        Instantiate(coffeePrefab, position, Quaternion.identity);
    }
}