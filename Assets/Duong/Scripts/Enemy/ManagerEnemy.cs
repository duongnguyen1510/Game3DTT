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

        private List<Enemy> listEnemy = new List<Enemy>();

        public List<Enemy> ListEnemy
        {
            get => listEnemy;
        }
        
        public int CountEnemyInWave { get; private set; }
        public int CountEnemyCurrent {get; private set; }
        
        public int LevelWave  {get; private set; }
        private void Awake()
        {
            Instance = this;
            StartCoroutine(HandleWaves());
        }

        
        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.Space) && !isSpawing)
        //     {
        //         StartCoroutine(HandleWaves());
        //     }
        // }

        IEnumerator HandleWaves()
        {
            int wave = 1;
            isSpawing = true;
            

            yield return new WaitForSeconds(10f); 

            while (true)
            {
                int numberEnemy = NumberEnemyInOneWare + wave * 2 - 2;
                LevelWave = wave;
                wave++;
                yield return StartCoroutine(ISpawnWare(numberEnemy));
                
                yield return StartCoroutine(ISpawnWareNext());
            }
        }

        IEnumerator ISpawnWareNext()
        {
            while (listEnemy.Count > 0)
            {
                yield return null;
            }
            yield return new WaitForSeconds(15f);
        }

        IEnumerator ISpawnWare(int numberSpawm)
        {
            CountEnemyInWave = numberSpawm;
            CountEnemyCurrent = numberSpawm;
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
            
            listEnemy.Add(enemy);
        }

        public void EnemyDeath()
        {
            CountEnemyCurrent--;
        }
    }
}

