using UnityEngine;

public class VehicleSpawnScript : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 5f;

    private float nextTimeToSpawn = 0f;

    public GameObject vehicle;

    public Transform[] spawnPoints;

    void Update()
    {
        if(nextTimeToSpawn <= Time.time)
        {
            SpawnVehicle();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
    }

    void SpawnVehicle()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(vehicle, spawnPoint.position, spawnPoint.rotation);
    }
}
