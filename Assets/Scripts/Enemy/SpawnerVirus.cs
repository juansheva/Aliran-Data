using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVirus : MonoBehaviour
{
    public GameObject virusPrefabs;

    [SerializeField]
    private float virusSpeed;

    [SerializeField]
    private float firstEnemySpawnOnScore;

    [SerializeField]
    private float moreDifficult;

    private float respawnTime;
    private float timeSurvive;
    private Vector2 screenBounds;

    public List<GameObject> spawnedEnemy;
    private Pooling pool;

    // Start is called before the first frame update
    private void Start()
    {
        pool = new Pooling();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    private void Update()
    {
        RemoveEnemy();
    }

    private void FixedUpdate()
    {
        timeSurvive += Time.deltaTime;
        respawnTime += Time.deltaTime;
        if (timeSurvive > firstEnemySpawnOnScore)
        {
            virusSpeed += (Time.deltaTime / 5);
            if (respawnTime > 1)
            {
                //GameObject virus1 = Instantiate(virusPrefabs[0], new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y)), transform.rotation);
                GenerateEnemy(new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y)), virusSpeed);

                //VirusController virus1Controller = virus1.GetComponent<VirusController>();
                //virus1Controller.speed = virusSpeed;
                int random = Random.Range(0, 2);
                if (timeSurvive > moreDifficult && respawnTime > 1 && random == 1)
                {
                    GenerateEnemy(new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y)), virusSpeed * 1.2f);

                    //{
                    //    GameObject virus2 = Instantiate(virusPrefabs[0], new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y)), transform.rotation);
                    //    VirusController virus2Controller = virus2.GetComponent<VirusController>();
                    //    virus2Controller.speed = virusSpeed * 1.2f;
                    //}
                }
                respawnTime = 0;
            }
        }
    }

    private void GenerateEnemy(Vector2 _newPos, float _speed)
    {
        GameObject newEnemy;

        newEnemy = pool.GenerateFromPool(virusPrefabs, transform);

        newEnemy.transform.position = _newPos;
        VirusController virus = newEnemy.GetComponent<VirusController>();
        virus.FirstLaunch(_speed);
        //newEnemy.GetComponent<VirusController>().FirstLaunch(virusSpeed);

        spawnedEnemy.Add(newEnemy);
    }

    private void RemoveEnemy()
    {
        GameObject terrainToRemove = null;

        foreach (GameObject item in spawnedEnemy)
        {
            if (item.transform.position.x <= -screenBounds.x * 2)
            {
                terrainToRemove = item;
                break;
            }
        }

        // after found;
        if (terrainToRemove != null)
        {
            spawnedEnemy.Remove(terrainToRemove);
            pool.ReturnToPool(terrainToRemove);
        }
    }
}