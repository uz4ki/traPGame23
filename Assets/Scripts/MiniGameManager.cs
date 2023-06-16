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
            StartCoroutine(nameof(GameTimer));
        }

        private void SendGameResult()
        {
            GameManager.Instance.SendMiniGameResult(isCleared);
        }

        private IEnumerator GameTimer()
        {
            yield return new WaitForSeconds(LimitTime);
            SendGameResult();
        }
    }
}
