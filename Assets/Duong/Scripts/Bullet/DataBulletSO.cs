using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    [CreateAssetMenu(menuName = "Data/DataBulletSO", fileName = "DataBulletSO")]
    public class DataBulletSO : ScriptableObject
    {
        [SerializeField] private DataBullet _dataBullet;

        public DataBullet Bullet
        {
            get => _dataBullet;
        }
    }
    [System.Serializable]
    public class DataBullet
    {
        public float dame;
        public float speed;
    }
}
