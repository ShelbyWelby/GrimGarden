using UnityEngine;

public class PetStats : MonoBehaviour
{
    public float hunger = 100f;
    public float happiness = 100f;
    public float energy = 100f;
    public float decayRate = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hunger -= decayRate * Time.deltaTime;
        happiness -= decayRate * Time.deltaTime * 0.5f;
        energy -= decayRate * Time.deltaTime * 0.8f;

        if (hunger < 0) hunger = 0;
        if (happiness < 0) happiness = 0;
        if (energy < 0) energy = 0;
        Debug.Log($"Hunger: {hunger}, Happiness: {happiness}, Energy: {energy}");
    }
}
