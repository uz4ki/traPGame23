using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private MiniGameManager miniGameManager;
    private bool _isFirst;
    private void OnColliderEnter2D(Collider2D col)
    {
        if (!_isFirst) return;
        miniGameManager.isCleared = true;
    }
}
