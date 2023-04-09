using System;
using System.Collections;
using System.Collections.Generic;
using Script.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        private static int _score;
        private static int _life;

        public List<String> gameList;

        public static void ClearMiniGame()
        {
            _score++;
        }
        
        public static void FailMiniGame()
        {
            _life--;
        }


    }
}
