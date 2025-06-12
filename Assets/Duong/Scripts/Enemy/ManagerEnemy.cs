using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    public class ManagerEnemy : MonoBehaviour
    {
        public const int NumberEnemyInOneWare = 10;
        public static ManagerEnemy Instance;
        
        [Space,Header("Enemy")]
        [SerializeField] private Enemy Enemyprefab;
        [SerializeField] private Transform TransEnemy;
        [SerializeField] private SpawnMap SpawnMap;

        private bool isSpawing = false;
        
        
        private void Awake()
        {
            Instance = this;
        }

        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isSpawing)
            {
                StartCoroutine(HandleWaves());
            }
        }

        IEnumerator HandleWaves()
        {
            int wave = 0;
            isSpawing = true;

            yield return new WaitForSeconds(10f); 

            while (true)
            {
                int numberEnemy = NumberEnemyInOneWare + wave * 2;
                wave++;
                yield return StartCoroutine(ISpawnWare(numberEnemy)); 
                yield return new WaitForSeconds(15f); 
            }
        }

        IEnumerator ISpawnWare(int numberSpawm)
        {
            for (int i = 0; i < numberSpawm; i++)
            { 
                SpawnEnemy();
                yield return new WaitForSeconds(1f);
            }
        }

        
        private void SpawnEnemy()
        {
            Enemy enemy = Instantiate(Enemyprefab, TransEnemy);
            enemy.SetUpData(SpawnMap.ListPath);
            Vector3 popSpawn = SpawnMap.ListPath[0].transform.position;
            popSpawn.x -= 1.5f;
            enemy.transform.position = popSpawn;
        }
    }
}

