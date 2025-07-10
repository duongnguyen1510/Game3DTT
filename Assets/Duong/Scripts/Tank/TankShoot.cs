using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    public class TankShoot : MonoBehaviour
    {
        [Space, Header("Spawm")] 
        [SerializeField] private Transform _spawnPoint;
        
        private ManagerEnemy managerEnemy;
        private float timeDelayShoot;
        private Tank tank;
        private DataTank Data;
        private float rangeAtt => Data.rangeAtt /2;
        private float SpeedAtt => Data.speed;

        public void Initialize(DataTank Data, Tank tank)
        {
            this.Data = Data;
            this.tank = tank;
        }

        private void Update()
        {
            if (GameManager.StartGameCurrent != EStartGame.PLAY || tank.StartTankCurrent != EStartTank.PLAY)
            {
                return;
            }
            if (managerEnemy == null)
            {
                managerEnemy = ManagerEnemy.Instance;
            }

            if (timeDelayShoot <= 0)
            {
                List<Enemy> listEnemyCurrrnt = managerEnemy.ListEnemy;
                if (listEnemyCurrrnt.Count > 0)
                {
                    foreach (Enemy enemy in listEnemyCurrrnt)
                    {
                        Vector3 posEnemy = enemy.transform.position;
                        Vector3 posCurrent = transform.position;
                        float distance = Vector3.Distance(posEnemy, posCurrent);
                        if (distance <= rangeAtt && enemy.allowedToShoot)
                        {
                            tank.SpawnBullet(enemy);
                            timeDelayShoot = SpeedAtt;
                            break;
                        }
                    }
                }
                
            }

            if (timeDelayShoot >= 0)
            {
                timeDelayShoot -= Time.deltaTime;
            }
            else
            {
                timeDelayShoot = 0;
            }
        }
    }
}
