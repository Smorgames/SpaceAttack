using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerForMenu : MonoBehaviour
{
    public GameObject enemy, player;
    private bool flag;
    void Start()
    {
        flag = true;
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        while (true)
        {
            if (flag == true)
            {
                yield return new WaitForSeconds(Random.Range(0.5f, 2f));
                Instantiate(player, new Vector3(transform.position.x, Random.Range(0.0f, 3.3f), transform.position.z), Quaternion.Euler(0, 0, 90));
                for (int i = 0; i < 3; i++)
                {
                    yield return new WaitForSeconds(0.4f);
                    Instantiate(enemy, new Vector3(transform.position.x, Random.Range(0.0f, 3.3f), transform.position.z), Quaternion.Euler(0, 0, -90));
                }
                flag = false;
            }
            else
            {
                yield return new WaitForSeconds(30f);
                Instantiate(player, new Vector3(transform.position.x, Random.Range(0.0f, 3.3f), transform.position.z), Quaternion.Euler(0, 0, 90));
                for (int i = 0; i < 3; i++)
                {
                    yield return new WaitForSeconds(0.4f);
                    Instantiate(enemy, new Vector3(transform.position.x, Random.Range(0.0f, 3.3f), transform.position.z), Quaternion.Euler(0, 0, -90));
                }
            }
        }
    }
}

//yield return new WaitForSeconds(30f);
//Instantiate(player, new Vector3(transform.position.x, Random.Range(0.0f, 3.3f), transform.position.z), Quaternion.Euler(0, 0, 90));
//                for (int i = 0; i< 3; i++)
//                {
//                    yield return new WaitForSeconds(0.4f);
//                    Instantiate(enemy, new Vector3(transform.position.x, Random.Range(0.0f, 3.3f), transform.position.z), Quaternion.Euler(0, 0, -90));
//                }
