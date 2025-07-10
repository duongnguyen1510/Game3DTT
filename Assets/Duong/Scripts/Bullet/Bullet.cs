using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    public class Bullet : MonoBehaviour
    {
        private Enemy enemyTarget;
        private DataBullet dataBullet;

        public void SetUpData(DataBullet dataBullet,Enemy enemyTarget)
        {
            this.dataBullet = dataBullet;
            this.enemyTarget = enemyTarget;
        }

        public void Update()
        {
            if (enemyTarget != null)
            {
                Vector3 posEnemy = enemyTarget.TransPosTarget.position;
                Vector3 posCurrent = transform.position;
                float distance = Vector3.Distance(posEnemy, posCurrent);
                if (distance > 0.05f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, posEnemy, dataBullet.speed * Time.deltaTime);
                }
                else
                {
                    enemyTarget.TakeDamage(dataBullet.dame);
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
