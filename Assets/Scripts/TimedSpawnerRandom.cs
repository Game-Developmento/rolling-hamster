using System.Collections;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class TimedSpawnerRandom : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")][SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")][SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")][SerializeField] float minXDistance = 10f;
    [Tooltip("Minimum distance in X between spawner and spawned objects, in meters")][SerializeField] float maxXDistance = 15f;

    void Start()
    {
        this.StartCoroutine(SpawnRoutine());

    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(minXDistance, maxXDistance),
                transform.position.y,
                transform.position.z);
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
        }
    }
}