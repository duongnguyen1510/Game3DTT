using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    public class TankVisual : MonoBehaviour
    {
        [Space, Header("Components")] 
        [SerializeField] private Transform[] _transPointsSpawn;
        [SerializeField] private Transform _transVisualShoot;
        [SerializeField] private DataBulletSO _dataBullet;

        public Transform[] TransPointsSpawn
        {
            get => _transPointsSpawn;
        }

        public Transform TransVisualShoot
        {
            get => _transVisualShoot;
        }

        public DataBulletSO DataBullet
        {
            get=> _dataBullet;
        }
    }
}
