using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Duong
{
    public class UILevelWave : MonoBehaviour
    {
        [SerializeField] private Text text_wave;
        
        private ManagerEnemy LevelWave;

        public void Update()
        {
            if (LevelWave == null)
            {
                LevelWave = ManagerEnemy.Instance;
            }

            if (LevelWave != null)
            {
                text_wave.text = $"Level: {LevelWave.LevelWave}";
            }
        }

    }
}
