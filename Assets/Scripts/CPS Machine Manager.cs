using UnityEngine;

public class CPSMachineManager : MonoBehaviour
{
    CurrencyManager c;

    [Header("Identity")]
    public string machineName;

    [HideInInspector] public int machinesOwned = 0;

    [Header("Production")]
    public int craigsPerSecondPerMachine = 1;

    [Header("Cost")]
    [Tooltip("The cost of this machine the first time you buy it.")]
    public float baseCost;
    [Tooltip("The cost of the next machine will be multiplied by this amount.")]
    public float costMultiplierPerMachine;

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

    public void BuyMachine()
    {
        if (canAfford)
        {
            c.currentCraigsInternal -= currentCost;
            machinesOwned++;
            c.craigsPerSecond += craigsPerSecondPerMachine;
            currentCost = Mathf.FloorToInt(baseCost * Mathf.Pow(costMultiplierPerMachine, machinesOwned));
        }
        else
        {
            return;
        }
    }
}