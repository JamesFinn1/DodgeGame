using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployFireballs : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float respawnTime = 2.0f;
    private float maximumX;

    private Camera cam;
    private float width;
    private float height;

    public float RespawnTime
    {
        get { return respawnTime; }
        set { respawnTime = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        maximumX = width / 2f;
        Debug.Log("Respawn time fireball = " + respawnTime);
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(FireBallWave());
    }

    private void SpawnFireBall()
    {
        GameObject a = Instantiate(fireballPrefab) as GameObject;
        //a.transform.position = new Vector2(screenBounds.y * 10, Random.Range(-screenBounds.y, screenBounds.y * 2));
        a.transform.position = new Vector2(Random.Range(-maximumX, maximumX), 24.0f);
    }

    IEnumerator FireBallWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnFireBall();
        }
        
    }

    public void SetRespawnTime(float newVal)
    {
        respawnTime = newVal;
    }

}
