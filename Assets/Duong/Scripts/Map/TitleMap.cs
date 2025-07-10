using System.Collections;
using System.Collections.Generic;
using Duong;
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
        [SerializeField] private Outline outline;
        private Tank currentTank = null;

        public int rows;
        public int cols;

        public void SetupTitleMap(TitleMapType type, int cols, int rows)
        {
            this.cols = cols;
            this.rows = rows;
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
            EnableOutLine(false);
            gameOjbectWall.SetActive(false);
            gameOjbectTank.SetActive(false);
        }

        public void EnableOutLine(bool enable)
        {
            outline.enabled = enable;
        }

        public bool HasTank()
        {
            return currentTank != null;
        }
        public void SetTank(Tank tank)
        {
            currentTank = tank;
        }

        public Tank GetTank()
        {
            return currentTank;
        }

        public void removeTank()
        {
            currentTank = null;
        }
    }
}
