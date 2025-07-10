using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Duong
{
    public class UIEnemyCountInWave : MonoBehaviour
    {
        [SerializeField] private Text text_Count;

        private ManagerEnemy managerEnemy;

        public void Update()
        {
            if (managerEnemy == null)
            {
                managerEnemy = ManagerEnemy.Instance;
            }

            if (managerEnemy != null)
            {
                text_Count.text = $"Enemy: {managerEnemy.CountEnemyCurrent} / {managerEnemy.CountEnemyInWave}";
            }
        }
    }
}
