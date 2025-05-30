using System.Collections;
using System.Collections.Generic;
using HoangAnh;
using UnityEngine;

namespace Duong
{
    public class SpawnMap : MonoBehaviour
    {
        [SerializeField] private TitleMap   ;
        // 1 = Tanks
        // 0 = Wall
        private int[,] map = new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0, 0, 0 },
            { 1, 0, 1, 0, 1, 1, 1 },
            { 0, 0, 1, 0, 0, 0, 0 }
        };

        void Start()
        {
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    
                }
            }
        }
    }
}
