using UnityEngine;
using System.Collections;

public class CraigSpawner : MonoBehaviour
{
    public GameObject craigPrefab;
    public Transform spawnPoint;
    public float cooldownTime;
    public bool onCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void RunSpawner()
    {
        if (!onCooldown)
        {
            StartCoroutine(SpawnCraig());
        }
    }

    IEnumerator SpawnCraig()
    {
        Instantiate(craigPrefab, spawnPoint.position, spawnPoint.transform.rotation);
        onCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }

    /*public void InstantSpawn()
    {
        Instantiate(craigPrefab, spawnPoint.position, spawnPoint.transform.rotation);
    }*/
}
