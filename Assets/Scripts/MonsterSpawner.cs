using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;
    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {

        while (true)
        {

            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 5));

            randomIndex = UnityEngine.Random.Range(0, monsterReference.Length);
            randomSide = UnityEngine.Random.Range(0, 2);
            try
            {
                spawnedMonster = Instantiate(monsterReference[randomIndex]);
            }
            catch(Exception e)
            {
                continue;
            }

            // left side
            if (randomSide == 0)
            {

                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = UnityEngine.Random.Range(4, 10);

            }
            else
            {
                // right side
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -UnityEngine.Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
