using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Duong
{
    public class UIStartGame : MonoBehaviour
    {
        [SerializeField] private Button _btnStartGame;
        [SerializeField] private GameObject _uIGame;

        private void Awake()
        {
            _btnStartGame.onClick.AddListener(OnGame);
        }

        private void OnGame()
        {
            gameObject.SetActive(false);
            _uIGame.gameObject.SetActive(true);
            GameManager.SetStartGame(EStartGame.PLAY);
        }

        // private void ExitGame()
        // {
        //     Application.Quit();
        // }
    }
}
