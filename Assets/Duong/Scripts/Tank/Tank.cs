using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Duong
{
    public enum EStartTank
    {
        PLAY,
        PAUSE
    }
    public class Tank : MonoBehaviour
    {

        [SerializeField] private int levelTank;

        [FormerlySerializedAs("_TranSpawnVisual")]
        [Space, Header("Components")]
        [SerializeField] private Transform _transSpawnVisual;
        [SerializeField] private Transform _transRangeAtt;
        [SerializeField] private TankShoot _tankShoot;
        

        public int LevelTank
        {
            get => levelTank;
        }
        
        private DataTankManager dataManager;
        private DataTankSO dataTankSO;
        private DataTankContainerSO dataTankContainerSO;
        private DataBulletSO dataBulletSO;
        private TankVisual _tankVisual;
        public EStartTank StartTankCurrent { get; private set; }

        public TankVisual TankVisual
        {
            get => _tankVisual;
        }

        public void Intialize()
        {
            if (_tankShoot == null)
            {
                _tankShoot = transform.GetComponent<TankShoot>();
            }

            if (dataManager == null)
            {
                dataManager = DataTankManager.instance;
            }

            StartTankCurrent = EStartTank.PAUSE;
            ResetData();
        }

        public void ActiveTank()
        {
            StartTankCurrent = EStartTank.PLAY;
        }

        private void ResetData()
        {
            levelTank = 1;
            UpdateVisual();
        }

        public void UpLevel()
        {
            levelTank++;
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (dataTankContainerSO == null)
            {
                dataTankContainerSO = dataManager.DataTankContainerSO;
            }

            if (dataTankContainerSO.MaxLevel < levelTank)
            {
                levelTank = dataTankContainerSO.MaxLevel;
            }
            dataTankSO = dataTankContainerSO.GetDataTankSO(levelTank);
            _tankShoot.Initialize(dataTankSO.Data, this);
            
            if (_tankVisual != null)
            {
                Destroy(_tankVisual.gameObject);
            }
            _tankVisual = Instantiate(dataTankSO.Data.visualPrefab, _transSpawnVisual);
        }

        public void EnableRaneAtt(bool enable)
        {
            _transRangeAtt.gameObject.SetActive(enable);
        }

        public void SpawnBullet(Enemy enemy)
        {
            Transform[] pointsSpawn = TankVisual.TransPointsSpawn;
            foreach (var pointSpawn in pointsSpawn)
            {
                Bullet bullet = Instantiate(dataManager.BulletPrefab);
                bullet.SetUpData(_tankVisual.DataBullet.Bullet, enemy);
                bullet.transform.position = pointSpawn.position;
                Vector3 targetPosition = enemy.TransPosTarget.position;
                targetPosition.y = pointSpawn.position.y;
                Vector3 dir = (targetPosition - pointSpawn.position).normalized;
                _tankVisual.TransVisualShoot.rotation = Quaternion.LookRotation(dir);
            }
        }
    }
}
