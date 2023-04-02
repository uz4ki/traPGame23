using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Script
{
    public class MiniGameManager : MonoBehaviour
    {
        public bool isCleared;
        private void Start()
        {
            StartCoroutine("GameTimer");
            Initialization();
        }

        protected virtual void Initialization()
        {
            
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
            
        }

        private IEnumerator GameTimer()
        {
            yield return new WaitForSeconds(15f);
            EndGame();
        }
        
    }
}
