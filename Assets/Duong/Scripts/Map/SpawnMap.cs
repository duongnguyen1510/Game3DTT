using System.Collections;
using System.Collections.Generic;
using HoangAnh;
using UnityEditor;
using UnityEngine;

namespace Duong
{
    public class SpawnMap : MonoBehaviour
    {
        [SerializeField] private TitleMap TitleMapPrefab;
        [SerializeField] private Transform transSpawnLevel;

        [SerializeField] private SpawnEnemy spawnEnemy;
        
        public int level = 1;
        public int quantityEnemy = 10;
        public int increasePerLevel = 2;
        
        // 1 = Tanks
        // 0 = Wall
        private int[,] map = new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 0 },
            { 1, 0, 1, 0, 0, 0, 0 },
            { 1, 0, 1, 0, 1, 1, 1 },
            { 1, 0, 1, 0, 0, 0, 0 }
        };

        void Start()
        {
            float spacing = 1f;
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            float offsetX = (cols - 1) / 2f;
            float offsetY = (rows - 1) / 2f;
            int index = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    index++;
                    TitleMap titleMap = Instantiate(TitleMapPrefab, transSpawnLevel);
                    titleMap.transform.name = $"TitleMap_{index}";
                    
                    float posX = (j - offsetX) * spacing;
                    float posZ = -(i - offsetY) * spacing;
                    titleMap.transform.localPosition = new Vector3(posX, 0, posZ);
                    int valueMap = map[i, j];
                    titleMap.SetupTitleMap((TitleMapType)valueMap);
                }
            }
            spawnEnemy.Initialize(map.GetLength(0), map.GetLength(1));
            spawnEnemy.SpawnPoin(new Vector3(-2f, 1.8f, -0.2f));
        }
    }
}
