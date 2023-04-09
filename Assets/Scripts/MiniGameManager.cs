using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Script
{
    public class MiniGameManager : MonoBehaviour
    {
        [SerializeField] private float limitTime;
        public bool isCleared;
        private void OnEnable()
        {
            StartCoroutine("GameTimer");
            Initialization();
        }

        protected virtual void Initialization()
        {
            isCleared = false;
        }

        public virtual void Clear()
        {
            isCleared = true;
        }
        
        public virtual void GameOver()
        {
            isCleared = false;
        }
        
        protected virtual void EndGame()
        {
            if (isCleared) GameManager.ClearMiniGame();
            else GameManager.FailMiniGame();
        }

        private IEnumerator GameTimer()
        {
            yield return new WaitForSeconds(limitTime);
            EndGame();
        }
    }
}
