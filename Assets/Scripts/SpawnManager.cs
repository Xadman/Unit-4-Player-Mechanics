using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // created a new game object
    public GameObject powerupPrefab;  // created a new game object
    private float spawnRange = 9.0f; //created a variable
    public int enemyCount; //created a variable
    public int waveNumber = 1;//created a variable

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber); // starting the spawning of the enemies
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); //repeating the spawing of eneimesonce a condition is met

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // Telling system to find out how mwny enemy objects there are

        if(enemyCount == 0) // if enemy count is = 0 
        {
            waveNumber++; // increase the wave number by 1
           SpawnEnemyWave(waveNumber); // spawn enemies at new number 
           Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); //repeating the spawn of game object enemis as well as powerups

        }
    }

     void SpawnEnemyWave(int enemiesToSpawn) 
    {
        for (int i = 0; i < enemiesToSpawn ; i++) // enemies to spawn are supposed to be + 1 more each time
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); //repeating the spawn of game object enemis as well as powerups
        }
    }
    
    private Vector3 GenerateSpawnPosition()
    {
        float SpawnPosX = Random.Range(-spawnRange, spawnRange); // setting enemies to spawn at a random range from the player (-) the player position on x axis
        float SpawnPosZ = Random.Range(-spawnRange, spawnRange);// setting enemies to spawn at a random range from the player (-) the player position on z axis

        Vector3 randomPos = new Vector3(SpawnPosX, 0, SpawnPosZ); // setting enemies to spawn at a random range from the player (-) the player position on x and z axis
        return randomPos;
    }
}
