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
        }

        private void EndGame()
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
