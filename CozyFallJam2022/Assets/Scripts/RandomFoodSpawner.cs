using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFoodSpawner : MonoBehaviour
{
    public GameObject[] allIngredients;
    public float spawnTime; // how often to spawn
    private float timeLeft; // timer
    public bool spawning = false; // spawn after directions

    public GameObject bowl; // so the food spawns on same layer as bowl
    private SpriteRenderer targetRend;

    private void Start()
    {
        //SpawnIngredient();
        timeLeft = spawnTime;
    }

    private void Update()
    {
        if (spawning)
        {
            // if there's time before the next spawn
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }

            // if it's time to spawn
            else
            {
                SpawnIngredient();
                timeLeft = spawnTime; // reset the timer
            }
        }
    }

    public void TurnOnSpawning()
    {
        spawning = true;
    }

    public void SpawnIngredient()
    {
        int randomIndex = Random.Range(0, allIngredients.Length);
        Vector2 randomSpawnPosition = new Vector2(Random.Range(-7, 7), 7);
        
        GameObject food = (GameObject) Instantiate(allIngredients[randomIndex], randomSpawnPosition, Quaternion.identity); //spawn random food at random position with no additional rotation
        targetRend = bowl.GetComponent<SpriteRenderer>();
        SpriteRenderer spawnedRend = food.GetComponent<SpriteRenderer>();
        spawnedRend.sortingLayerName = targetRend.sortingLayerName;
    }
}
