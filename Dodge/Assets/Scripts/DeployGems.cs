using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployGems : MonoBehaviour
{
    [SerializeField] private GameObject gemPrefab;
    [SerializeField] private ProgressionBar progressionBar;
    private float maximumX;

    // Timer varibales
    private float timeLeft = 15f;
    private bool timerOn = false;

    [SerializeField] private float firstGemTime = 60;
    [SerializeField] private float OTHER_GEM_TIME = 90;
 
    private Camera cam;
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        maximumX = width / 2f;

        // Timer variables
        timeLeft = firstGemTime;
        timerOn = true;
    }

    private void SpawnGem()
    {
        GameObject a = Instantiate(gemPrefab) as GameObject;
        progressionBar.SetProgressionBar(1f);
        a.transform.position = new Vector2(Random.Range(-maximumX, maximumX), 24.0f);
    }

    private void Update()
    {
        if(timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
               timeLeft = OTHER_GEM_TIME;
               Debug.Log("Spawned Gem!");
                    
               SpawnGem();
            }

        }
    }

}
