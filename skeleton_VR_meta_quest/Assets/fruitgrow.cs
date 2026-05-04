using UnityEngine;

public class FruitGrow : MonoBehaviour
{
    public GameObject fruit;
    public float growTime = 5f;

    void Start()
    {
        fruit.SetActive(false);
        Invoke(nameof(GrowFruit), growTime);
    }

    void GrowFruit()
    {
        fruit.SetActive(true);
    }
}