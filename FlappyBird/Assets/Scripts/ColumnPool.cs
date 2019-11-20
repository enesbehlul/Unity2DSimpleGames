using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 20;
    private GameObject[] columns;
    public GameObject columnPreFab;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned = 1.5f;
    public float spawnRate = 2f;

    public float columnMin = -1f;
    public float columnMax = 3.5f;
    private float spawnXposition = 5;
    private int currentColumn = 0;

    // Start is called before the first frame update
    void Start(){
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++) {
            columns[i] = (GameObject) Instantiate(columnPreFab, objectPoolPosition, Quaternion.identity);
        }  
    }

    // Update is called once per frame
    void Update() {
        timeSinceLastSpawned += Time.deltaTime;
        if (!GameControl.instance.gameOver && timeSinceLastSpawned >= spawnRate) {
            timeSinceLastSpawned = 0;
            float spawnYposition = Random.Range(columnMin,columnMax);
            columns[currentColumn++].transform.position = new Vector2(spawnXposition,spawnYposition);
            if (currentColumn >= columnPoolSize) {
                currentColumn = 0;
            }
        }
    }
}
