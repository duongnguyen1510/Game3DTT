using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public class SpawnMap : MonoBehaviour
    {
        [Space, Header("Title Map Prefab")] 
        [SerializeField] private TitleMap titleMapPrefab;

        [SerializeField] private Transform transSpawnLevel;
        
        /// <summary>
        /// 0. Title Way, 1. Title Tank 
        /// </summary>
        private int[,] maps = new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0, 0, 0 },
            { 1, 0, 1, 0, 1, 1, 1 },
            { 0, 0, 1, 0, 0, 0, 0 }
        };

        private void Start()
        {
            float spacing = 1f;
            int rows = maps.GetLength(0);
            int columns = maps.GetLength(1);
            float offsetX = (columns - 1) / 2f;
            float offsetY = (rows - 1) / 2f;
            int index = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    TitleMap title = Instantiate(titleMapPrefab, transSpawnLevel);
                    title.transform.name = $"TitleMap_{index}";
                    index++;
                    float posX = (j - offsetX) * spacing;
                    float posZ = -(i - offsetY) * spacing;
                    title.transform.localPosition = new Vector3(posX, 0, posZ);
                    int valueMap = maps[i, j];
                    title.SetupTitleMap((ETitleMap)valueMap);
                }
            }
        }
    }
}
