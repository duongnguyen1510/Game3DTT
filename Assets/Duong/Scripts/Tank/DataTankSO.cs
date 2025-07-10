using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    [CreateAssetMenu(menuName = "Data/DataTankSO", fileName = "DataTankSO")]

    public class DataTankSO : ScriptableObject
    {
        [SerializeField] private DataTank _data;

        public DataTank Data
        {
            get => _data;
        }
    }
    [System.Serializable]
    public class DataTank
    {
        public int idTank;
        public TankVisual visualPrefab;
        public float speed;
        public float rangeAtt;
        public int priceTank;
    }
}
