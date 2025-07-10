using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    [CreateAssetMenu(menuName = "DataEnemy/DataEnemySO", fileName = "DataEnemySO")]
    public class DataEnemySO : ScriptableObject
    {
        [SerializeField] private DataEnemy _dataEnemy;

        public DataEnemy Data
        {
            get => _dataEnemy;
        }
        
        [System.Serializable]
        public class DataEnemy
        {
            public int bonusEnemyDie;
            public int health;
        }
    }
}
