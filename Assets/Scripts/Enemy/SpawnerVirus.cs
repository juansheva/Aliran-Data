using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVirus : MonoBehaviour
{
    public GameObject[] virusPrefabs;

    [SerializeField]
    private float virusSpeed;

    private float respawnTime;
    private float timeSurvive;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        timeSurvive += Time.deltaTime;
        respawnTime += Time.deltaTime;
        if (timeSurvive > 8)
        {
            virusSpeed += (Time.deltaTime / 5);
            if (respawnTime > 1)
            {
                GameObject virus1 = Instantiate(virusPrefabs[0], new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y)), transform.rotation);
                VirusController virus1Controller = virus1.GetComponent<VirusController>();
                virus1Controller.speed = virusSpeed;
                if (timeSurvive > 40 && respawnTime > 1)
                {
                    GameObject virus2 = Instantiate(virusPrefabs[0], new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y)), transform.rotation);
                    VirusController virus2Controller = virus2.GetComponent<VirusController>();
                    virus2Controller.speed = virusSpeed * 1.2f;
                }
                respawnTime = 0;
            }
        }
    }
}