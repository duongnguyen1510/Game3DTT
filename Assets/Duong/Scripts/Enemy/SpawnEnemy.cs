using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject Enemyprefab;
        [SerializeField] private Transform SpanwPoin;
        [SerializeField] private float space = 1f;

        [SerializeField] private int quantityEnemy = 10;

        public int rows;
        public int cols;
        public float offsetY;
        public float offsetX;
        
        public void Initialize(int mapRows, int mapCols)
        {
            mapRows = rows;
            mapCols = cols;
            offsetX = (rows - 1) / 2f;
            offsetY = (rows - 1) / 2f;
        }

        public void SpawnPoin(Vector3 point)
        {
            int index = 1;
            for (int i = 0; i < quantityEnemy; i++)
            {
                index++;
                GameObject enemy = Instantiate(Enemyprefab, SpanwPoin);
                enemy.transform.localPosition = point;
                enemy.name = $"Enemy_{index}";
                
            }
        }
    }
}
