using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    public class DataTankManager : MonoBehaviour
    {
        public static DataTankManager instance;
        [SerializeField] private DataTankContainerSO _dataTankContainerSO;
        [SerializeField] private Bullet _bulletPrefab;

        public DataTankContainerSO DataTankContainerSO
        {
            get => _dataTankContainerSO;
        }

        public Bullet BulletPrefab
        {
            get => _bulletPrefab;
        }

        void Awake()
        {
            instance = this;
        }
        
    }
}
