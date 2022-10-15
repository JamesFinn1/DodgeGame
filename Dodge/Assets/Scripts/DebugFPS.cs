using UnityEngine;
using UnityEngine.UI;

public class DebugFPS : MonoBehaviour
{
    [SerializeField] private Text fpsText;
    private float pollingTime = 1f; // How many seconds betwween fps text refreshing
    private float time;
    private int frameCount;

    // Update is called once per frame
    void Update(){
        time += Time.deltaTime;
        frameCount++;

        if(time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount/time);
            fpsText.text = "FPS: " + frameRate.ToString();

            time -= pollingTime;
            frameCount = 0;
        }

    }
}
