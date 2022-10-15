using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployCoins : MonoBehaviour
{
    public GameObject coinPrefab;
    public float respawnTime = 4.0f;
    private float maximumX;

    private Camera cam;
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        // Getting maximum values for spawning coins 
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        maximumX = width / 2f;

        // Start of coroutine
        StartCoroutine(CoinWave()); 
    }

    private void SpawnCoin()
    {
        GameObject a = Instantiate(coinPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-maximumX, maximumX), 24.0f);
    }

    IEnumerator CoinWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnCoin();
        }
    }
}
