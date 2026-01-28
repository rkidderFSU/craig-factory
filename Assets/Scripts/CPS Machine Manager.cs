using UnityEngine;
using System;

public class CPSMachineManager : MonoBehaviour
{
    CurrencyManager c;

    [Header("Identity")]
    public string machineName;

    [HideInInspector] public int machinesOwned = 0;

    [Header("Production")]
    public double craigsPerSecondPerMachine = 1;

    [Header("Cost")]
    [Tooltip("The cost of this machine the first time you buy it.")]
    public double baseCost;
    [Tooltip("The cost of the next machine will be multiplied by this amount.")]
    public float costMultiplierPerMachine;

    [HideInInspector] public double currentCost;
    [HideInInspector] public bool canAfford;


    private void Start()
    {
        c = GameObject.Find("Currency Manager").GetComponent<CurrencyManager>();
        currentCost = baseCost;
    }

    private void Update()
    {
        canAfford = c.currentCraigs >= currentCost;
    }

    public void BuyMachine()
    {
        if (canAfford)
        {
            c.currentCraigs -= currentCost;
            machinesOwned++;
            c.craigsPerSecond += craigsPerSecondPerMachine;
            currentCost = Math.Floor(baseCost * Math.Pow(costMultiplierPerMachine, machinesOwned));
        }
        else
        {
            return;
        }
    }
}