using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private MiniGameManager miniGameManager;
    [SerializeField] private TextMeshProUGUI text;
    private bool _isFirst;

    private void Start()
    {
        _isFirst = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!_isFirst) return;
        _isFirst = false;
        miniGameManager.isCleared = true;
        text.text = "Clear!";
    }
}
