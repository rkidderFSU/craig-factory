using UnityEngine;
using System;

public class CPSMachineUpgradeManager : MonoBehaviour
{
    CurrencyManager c;
    [Tooltip("Which machine this manager upgrades.")]
    public CPSMachineManager machine;

    [Header("Identity")]
    public string[] upgradeNames;

    [HideInInspector] public double upgradesOwned = 0;

    [Header("Production")]
    public double craigMultiplierPerUpgrade = 2;

    [Header("Cost")]
    [Tooltip("The cost of this upgrade the first time you buy it.")]
    public double baseCost;
    [Tooltip("The cost of the next upgrade will be multiplied by this amount.")]
    public double costMultiplierPerUpgrade;

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

    public void BuyUpgrade()
    {
        if (canAfford)
        {
            c.currentCraigs -= currentCost;
            upgradesOwned++;
            c.craigsPerSecond += machine.craigsPerSecondPerMachine * machine.machinesOwned; // Retroactive increase to CpS
            machine.craigsPerSecondPerMachine *= craigMultiplierPerUpgrade; // New machines will be more powerful
            currentCost = Math.Floor(baseCost * Math.Pow(costMultiplierPerUpgrade, upgradesOwned));
            // CycleUpgradeName();
        }
        else
        {
            return;
        }
    }

    void CycleUpgradeName()
    {
        // have a list of upgrade names (done)
        // remove the first entry
    }
}