using System;
using System.Collections;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class InGameGUIHandler : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        [SerializeField] private Image[] lifeImages;
        [SerializeField] private TextMeshProUGUI scoreText;

        private void OnEnable()
        {
            GameManager.Instance.OnUpdateGameStatus.AddListener(UpdateGameStatus);
        }

        private void OnDisable()
        {
            GameManager.Instance.OnUpdateGameStatus.RemoveListener(UpdateGameStatus);
        }
        
        private void UpdateGameStatus(bool isCleared)
        {
            if (isCleared)
            {
                scoreText.text = GameManager.Instance.score.ToString();
            }
            else
            {
                var lifeNum = GameManager.Instance.life;
                lifeImages[lifeNum].gameObject.SetActive(false);
            }
        }
        
        public void UpShutter()
        {
            animator.Play("UpShutter");
        }
        
        public void DownShutter()
        {
            animator.Play("DownShutter");
        }
    }
}