using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class InGameGUIHandler : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
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