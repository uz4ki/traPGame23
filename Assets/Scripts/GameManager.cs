using System;
using System.Collections;
using System.Collections.Generic;
using Script.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Script
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private MiniGameLoader miniGameLoader;
        
        public int score;
        public int life;

        private bool _isFinishedAtThisFrame;
        private bool _isClearedMiniGame;

        public List<String> gameList;

        private IEnumerator Flow()
        {
            // スタート時の演出
            StartCoroutine(miniGameLoader.LoadScenes(5));

            while (life > 0)
            {
                yield return PlayMiniGameCoroutine();
                if (miniGameLoader.loadedScenes.Count < 3) StartCoroutine(miniGameLoader.LoadScenes(3));
            }
            
            // ゲームオーバー
        }

        private IEnumerator PlayMiniGameCoroutine()
        {
            miniGameLoader.StartScene();
            
            // ブリッジシーン遷移

            while (!_isFinishedAtThisFrame)
            {
                yield return null;
            }

            _isFinishedAtThisFrame = false;
            
            // ブリッジシーン遷移
            
            miniGameLoader.UnloadScene();
            
            // ライフ処理
        }

        public void SendMiniGameResult(bool isCleared)
        {
            _isClearedMiniGame = isCleared;
            if (_isClearedMiniGame)
            {
                score++;
            }
            else
            {
                life--;
            }
            _isFinishedAtThisFrame = true;
        }
    }
}
