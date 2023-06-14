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
        [SerializeField] private MiniGameLoader _miniGameLoader;
        
        private static int _score;
        private static int _life;

        private static bool _isFinishedAtThisFrame;

        public List<String> gameList;

        private IEnumerator Flow()
        {
            // スタート時の演出
            
            while (_life > 0)
            {
                yield return PlayMiniGameCoroutine();
            }
            
            // ゲームオーバー
        }

        private IEnumerator PlayMiniGameCoroutine()
        {
            _miniGameLoader.StartScene();
            
            // ブリッジシーン遷移

            while (!_isFinishedAtThisFrame)
            {
                yield return null;
            }

            _isFinishedAtThisFrame = false;
            
            // ブリッジシーン遷移
            
            _miniGameLoader.UnloadScene();
            
            // ライフ処理
        }

        public static void ClearMiniGame()
        {
            _score++;
            _isFinishedAtThisFrame = true;
        }
        
        public static void FailMiniGame()
        {
            _life--;
            _isFinishedAtThisFrame = true;
        }


    }
}
