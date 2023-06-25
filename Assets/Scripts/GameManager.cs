using System;
using System.Collections;
using System.Collections.Generic;
using Script.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Script
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private MiniGameLoader miniGameLoader;
        
        public int score;
        public int life = 5;

        private bool _isFinishedAtThisFrame;
        private bool _isClearedMiniGame;

        public List<String> gameList;
        [SerializeField] private InGameGUIHandler inGameGUIHandler;


        public void Start()
        {
            StartCoroutine(Flow());
        }

        private IEnumerator Flow()
        {
            yield return miniGameLoader.LoadScenes(5);
            // スタート時の演出
            

            while (life > 0)
            {
                yield return PlayMiniGameCoroutine();
            }
            
            // ゲームオーバー
        }

        private IEnumerator PlayMiniGameCoroutine()
        {
            miniGameLoader.StartScene();
            if (miniGameLoader.loadedScenes.Count < 4)
            {
                StartCoroutine(miniGameLoader.LoadScenes(3));
            }

            // ブリッジシーン遷移
            inGameGUIHandler.UpShutter();
            
            while (!_isFinishedAtThisFrame)
            {
                yield return null;
            }

            _isFinishedAtThisFrame = false;
            
            // ブリッジシーン遷移
            inGameGUIHandler.DownShutter();

            miniGameLoader.UnloadScene();
            
            // ライフ処理
            yield return new WaitForSeconds(2f);

            yield return null;
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
