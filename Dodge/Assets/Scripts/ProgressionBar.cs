using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionBar : MonoBehaviour
{
    public Slider slider;
    private float startVal = 1f;
    private float endVal = 0f;

    // Declaration with tool tip in editor
    [Tooltip("Time Limit In Seconds")]
    [SerializeField] private float progressBarTimeLimit = 10;
    float currentTime = 0;

    public float ProgressBarTime
    {
        get { return progressBarTimeLimit; }
        set { progressBarTimeLimit = value; }
    }

    public float ProgressBarCurrentTime
    {
        get { return currentTime; }
        set { currentTime = value; }
    }

    public void SetProgressionMax(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void SetProgressionBar(float progressionVal)
    {
        slider.value = progressionVal;
    }

    private void Start()
    {
        Debug.Log("ProgressionBar Start");
        slider.value = slider.maxValue;
    }

    // When game object is created perform lerp
    private void Update()
    {
        currentTime += Time.deltaTime;

        slider.value = Mathf.Lerp(startVal, endVal, currentTime / progressBarTimeLimit);
    }

    public void DisplayProgressBar()
    {
        this.gameObject.SetActive(true);
    }


}
