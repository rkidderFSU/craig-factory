using UnityEngine;

public class PrestigeManager : MonoBehaviour
{
    CurrencyManager c;

    public double craigsRequiredToPrestige;
    public double currentPrestigePoints;
    public double prestigePointsPerPrestige = 1;

    bool canPrestige;
    bool havePrestigedAtLeastOnce;

    [HideInInspector] public double numberOfTimesPrestiged;

    public CPSMachineManager[] machinesToReset;
    public UniversalMachineUpgradeManager[] upgradesToReset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c = GameObject.Find("Currency Manager").GetComponent<CurrencyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        canPrestige = c.craigsThisRun >= craigsRequiredToPrestige;
    }

    void Prestige()
    {
        // Reset machines
        foreach (CPSMachineManager machine in machinesToReset)
        {
            machine.machinesOwned = 0;
            machine.craigsPerSecondPerMachine = machine.baseCraigsPerSecondPerMachine;
            machine.RecalculateCost();
        }
        // Reset upgrades
        foreach (UniversalMachineUpgradeManager upgrade in upgradesToReset)
        {
            upgrade.upgradesOwned = 0;
            upgrade.RecalculateCost();
        }
        // Reset Craigs
        c.craigsThisRun = 0;
        c.currentCraigs = 0;
        c.craigsPerSecond = 0;

        if (!havePrestigedAtLeastOnce)
        {
            // Unlock the prestige upgrade menu if this is your first prestige (not yet implemented)
            havePrestigedAtLeastOnce = true;
        }
        numberOfTimesPrestiged++;
        currentPrestigePoints += prestigePointsPerPrestige * numberOfTimesPrestiged;
    }
}
