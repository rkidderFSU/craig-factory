using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public int currentCraigs; // This is the rounded value that is displayed on screen
    public float currentCraigsInternal; // This is the real value and is used in all of the math
    public float craigsPerSecond;
    public float craigsPerClick;

    public TextMeshProUGUI currentCraigsText;
    public TextMeshProUGUI craigsPerSecondText;

    CraigSpawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = GameObject.Find("Craig Spawner").GetComponent<CraigSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (craigsPerSecond > 0)
        {
            ProduceCraigOverTime();
            spawner.RunSpawner();
        }
    }

    private void LateUpdate()
    {
        UpdateText();
    }

    string FormatValue(float value)
    {
        if (value < 1000000f)
        {
            return Mathf.FloorToInt(value).ToString();
        }
        else
        {
            return value.ToString("0.00e0");
        }
    }

    void UpdateText()
    {
        currentCraigsText.text = "Current Craigs: " + FormatValue(currentCraigsInternal);
        craigsPerSecondText.text = "Craigs per Second: " + FormatValue(craigsPerSecond);
    }

    void ProduceCraigOverTime()
    {
        currentCraigsInternal += craigsPerSecond * Time.deltaTime; // Generates Craigs every frame based on your CpS amount
        currentCraigs = Mathf.FloorToInt(currentCraigsInternal); // Rounds Craig down to the nearest integer
    }

    public void ProduceCraigInstant()
    {
        currentCraigsInternal += craigsPerClick;
        currentCraigs = Mathf.FloorToInt(currentCraigsInternal);
        if (craigsPerSecond == 0)
        {
            spawner.RunSpawner();
        }
    }
}
