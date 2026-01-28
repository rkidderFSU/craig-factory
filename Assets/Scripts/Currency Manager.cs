using UnityEngine;
using TMPro;
using System;

public class CurrencyManager : MonoBehaviour
{
    public double currentCraigs;
    public double craigsPerSecond;
    public double craigsPerClick;

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

    string FormatValue(double value)
    {
        // Rounds to nearest integer when below one million, otherwise format in scientific notation to 2 decimal places
        if (value < 1000f)
        {
            return Math.Floor(value).ToString();
        }
        else if (value < 10000f)
        {
            return Math.Floor(value).ToString("0,000");
        }
        else if (value < 100000f)
        {
            return Math.Floor(value).ToString("00,000");
        }
        else if (value < 1000000f)
        {
            return Math.Floor(value).ToString("000,000");
        }
        else
        {
            return value.ToString("0.00e0");
        }
    }

    void UpdateText()
    {
        currentCraigsText.text = "Current Craigs: " + FormatValue(currentCraigs);
        craigsPerSecondText.text = "Craigs per Second: " + FormatValue(craigsPerSecond);
    }

    void ProduceCraigOverTime()
    {
        currentCraigs += craigsPerSecond * Time.deltaTime; // Generates Craigs every frame based on your CpS amount
    }

    public void ProduceCraigInstant()
    {
        currentCraigs += craigsPerClick;
        if (craigsPerSecond == 0)
        {
            spawner.RunSpawner();
        }
    }
}
