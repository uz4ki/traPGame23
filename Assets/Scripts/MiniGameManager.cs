using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Script
{
    public class MiniGameManager : MonoBehaviour
    {
        private const float LimitTime = 5f;
        public bool isCleared;
        protected virtual void OnEnable()
        {
            StartCoroutine("GameTimer");
        }

        private void SendGameResult()
        {
            if (isCleared) GameManager.ClearMiniGame();
            else GameManager.FailMiniGame();
        }

        private IEnumerator GameTimer()
        {
            yield return new WaitForSeconds(LimitTime);
            SendGameResult();
        }
    }
}
