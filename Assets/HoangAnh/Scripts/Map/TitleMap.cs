using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public enum ETitleMap
    {
        TANK = 1,
        WALL = 0
    }
    public class TitleMap : MonoBehaviour
    {
        [Space, Header("Data Title")] 
        public ETitleMap TypeTitleMap;

        [Space, Header("GameObjTitle")] 
        [SerializeField] private GameObject objTitleTank;
        [SerializeField] private GameObject objTitleWall;

        public void SetupTitleMap(ETitleMap type)
        {
            ResetData();
            TypeTitleMap = type;
            switch (type)
            {
                case ETitleMap.TANK:
                    objTitleTank.SetActive(true);
                    break;
                case ETitleMap.WALL:
                    objTitleWall.SetActive(true);
                    break;
            }
        }

        public void ResetData()
        {
            objTitleTank.SetActive(false);
            objTitleWall.SetActive(false);
        }
    }
}
