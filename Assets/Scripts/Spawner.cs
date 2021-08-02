using UnityEngine;

public class Spawner : MonoBehaviour
{
    //get reference of the prefab
    public GameObject fallingBlockPrefab;

    //calculate the screen size in world units  so we can know where to spawn the blocks
    Vector2 screenHalfSizeWorldUnits;


    public Vector2 secondsBetweenSpawnMinMax;

    float nextSpawnTime;


    // the x value is the minimum and the y value is the maximum
    public Vector2 spawnSizeMinMax;

    public float spawnAngleMax;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawn = Mathf.Lerp(secondsBetweenSpawnMinMax.y, secondsBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercent());
            // print(secondsBetweenSpawn);
            nextSpawnTime = Time.time + secondsBetweenSpawn;

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);

            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);

            //spawn position in the world between x and top of the screen
            Vector2 spawnPos = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);

            GameObject newBloack = (GameObject)Instantiate(fallingBlockPrefab, spawnPos, Quaternion.Euler(Vector3.forward * spawnAngle));

            newBloack.transform.localScale = Vector3.one * spawnSize;

            newBloack.transform.parent = transform;
        }
    }
}
