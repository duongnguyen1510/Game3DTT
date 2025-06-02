using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    public enum TitleMapType
    {
        Wall = 0,
        Tank = 1
    }
    public class TitleMap : MonoBehaviour
    {
        [Space,Header("Data Title")]
        public TitleMapType typeMap;
        
        [Space, Header("GameOject")]
        [SerializeField] private GameObject gameOjbectWall;
        [SerializeField] private GameObject gameOjbectTank;

        public int rows;
        public int clos;

        public void SetupTitleMap(TitleMapType type)
        {
            ResetData();
            typeMap = type;
            switch (type)
            {
                case TitleMapType.Wall:
                    gameOjbectWall.SetActive(true);
                    break;
                case TitleMapType.Tank:
                    gameOjbectTank.SetActive(true);
                    break;
            }
        }

        public void ResetData()
        {
            gameOjbectWall.SetActive(false);
            gameOjbectTank.SetActive(false);
        }

        public void SetPositionMap(int maprows, int mapclos)
        {
            mapclos = rows;
            mapclos = clos;
        }
    }
}
