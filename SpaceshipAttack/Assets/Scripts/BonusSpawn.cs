using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawn : MonoBehaviour
{
    public GameObject speedBonus, damageBonus;
    private void Start()
    {
        StartCoroutine(SpawnBonus());
    }
    IEnumerator SpawnBonus()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(15f, 30f));
            int i = Random.Range(0, 2);
            if (i == 0)
                Instantiate(speedBonus, new Vector3(transform.position.x, Random.Range(-2.5f, 2.5f), transform.position.z), Quaternion.Euler(0, 0, -90));
            if (i == 1)
                Instantiate(damageBonus, new Vector3(transform.position.x, Random.Range(-2.5f, 2.5f), transform.position.z), Quaternion.Euler(0, 0, -90));
        }
    }
}
