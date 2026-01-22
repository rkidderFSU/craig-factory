using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public int currentCraigs;
    public float currentCraigsInternal;
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

    void UpdateText()
    {
        currentCraigsText.text = "Current Craigs: " + currentCraigs;
        craigsPerSecondText.text = "Craigs per Second: " + craigsPerSecond;
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
