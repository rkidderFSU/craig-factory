using UnityEngine;

public class CPSMachineUpgradeManager : MonoBehaviour
{
    CurrencyManager c;
    [Tooltip("Which machine this manager upgrades.")]
    public CPSMachineManager machine;

    [Header("Identity")]
    public string upgradeName;

    [HideInInspector] public int upgradesOwned = 0;

    [Header("Production")]
    public int craigMultiplierPerUpgrade = 2;

    [Header("Cost")]
    [Tooltip("The cost of this upgrade the first time you buy it.")]
    public float baseCost;
    [Tooltip("The cost of the next upgrade will be multiplied by this amount.")]
    public float costMultiplierPerUpgrade = 10f;

    [HideInInspector] public float currentCost;
    [HideInInspector] public bool canAfford;


    private void Start()
    {
        c = GameObject.Find("Currency Manager").GetComponent<CurrencyManager>();
        currentCost = baseCost;
    }

    private void Update()
    {
        canAfford = c.currentCraigsInternal >= currentCost;
    }

    public void BuyUpgrade()
    {
        if (canAfford)
        {
            c.currentCraigsInternal -= currentCost;
            upgradesOwned++;
            c.craigsPerSecond += machine.craigsPerSecondPerMachine * machine.machinesOwned; // Retroactive increase to CpS
            machine.craigsPerSecondPerMachine *= craigMultiplierPerUpgrade; // New machines will be more powerful
            currentCost = Mathf.FloorToInt(baseCost * Mathf.Pow(costMultiplierPerUpgrade, upgradesOwned));
        }
        else
        {
            return;
        }
    }
}