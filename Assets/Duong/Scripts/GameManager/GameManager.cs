using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    public enum EStartGame
    {
        NONE,
        PLAY,
        PAUSE
    }

    public class GameManager : MonoBehaviour
    {
        public static EStartGame StartGameCurrent { get; private set; }

        private void Awake()
        {
            StartGameCurrent = EStartGame.NONE;
        }

        public static void SetStartGame(EStartGame startGame)
        {
            StartGameCurrent = startGame;
        }
    }
}
