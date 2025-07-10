using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Duong
{
    public class SpawnMap : MonoBehaviour
    {   [Space, Header("Title Map Prefab")]
        [SerializeField] private TitleMap TitleMapPrefab;
        [SerializeField] private Transform transSpawnLevel;
        
        public List<TitleMap> ListPath = new List<TitleMap>();
        
        
        
        // 1 = Tanks
        // 0 = Wall
        private int[,] map = new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1},
            { 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1},
            { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0}
        };
        
        private List<TitleMap> listTitlesMap = new List<TitleMap>();

        private void Start()
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
                    titleMap.SetupTitleMap((TitleMapType)valueMap, j, i);
                    listTitlesMap.Add(titleMap);
                }
            }

            ListPath = FindPathAuto();
        }

        private List<TitleMap> FindPathAuto()
        {
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            bool[,] visited = new bool[rows, cols];

            Vector2Int start = new Vector2Int(-1, -1);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (map[y, x] == 0)
                    {
                        start = new Vector2Int(x, y);
                        break;
                    }
                }

                if (start.x != -1) break;
            }

            if (start.x == -1)
            {
                Debug.LogWarning("Không tìm thấy điểm bắt đầu.");
                return new List<TitleMap>();
            }

            List<Vector2Int> pathCoords = new List<Vector2Int>();
            Queue<Vector2Int> queue = new Queue<Vector2Int>();
            queue.Enqueue(start);
            visited[start.y, start.x] = true;

            Vector2Int[] directions = new Vector2Int[]
            {
                new Vector2Int(0, 1), 
                new Vector2Int(1, 0), 
                new Vector2Int(0, -1), 
                new Vector2Int(-1, 0) 
            };

            while (queue.Count > 0)
            {
                Vector2Int current = queue.Dequeue();
                pathCoords.Add(current);

                foreach (var dir in directions)
                {
                    Vector2Int next = current + dir;
                    if (next.x >= 0 && next.x < cols &&
                        next.y >= 0 && next.y < rows &&
                        !visited[next.y, next.x] &&
                        map[next.y, next.x] == 0)
                    {
                        visited[next.y, next.x] = true;
                        queue.Enqueue(next);
                        break;
                    }
                }
            }

            List<TitleMap> result = new List<TitleMap>();
            foreach (var coord in pathCoords)
            {
                foreach (var title in listTitlesMap)
                {
                    if (title.cols == coord.x && title.rows == coord.y)
                    {
                        result.Add(title);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
