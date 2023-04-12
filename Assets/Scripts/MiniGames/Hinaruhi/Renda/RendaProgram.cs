using System;
using Script;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.Hinaruhi.Renda
{
    public class RendaProgram : MiniGameManager
    {
        // 真ん中の「後〇回左クリック連打！！」の文字列を表示するオブジェクトを扱う変数
        // [SerializeField] を冒頭につけるとInspectorに枠が表示されて
        // Unityのエディターでアタッチができるようになる
        [SerializeField] private Text text;
        
        // 後何回連打するかを管理する変数
        private int _lastClickNum;
        
        // 「クリア」というテキストの表示を操作できる変数
        // テキストとかUIを表示・非表示する操作をしたい場合
        // CanvasGroupを使うと比較的簡単なのでおすすめ
        [SerializeField] private CanvasGroup clearCanvasGroup;

        
        // ゲームが始まった瞬間にこのStart()の { } の中が自動的に実行される。
        private void Start()
        {
            // 何回押すとクリアかをここで決める
            // UnityEngine.Random.Range(10, 15)とすると
            // 10～14の中からランダムな値を一つ決める
            _lastClickNum = UnityEngine.Random.Range(10, 15);
            
            // 真ん中のテキストを更新する
            // テキストを更新したいときは
            // text.text = $"表示したい文字列{ここに表示したい変数の名前を書く}"
            text.text = $"後{_lastClickNum}回左クリック連打！！";
            
            // 「クリア」というテキストをはじめ非表示にしておく
            // clearCanvasGroup.alphaに0～1を入れることでどのくらいの濃さで表示するか変更できる
            // つまりclearCanvasGroup.alpha = 0f; と書くと完全に透明にできる。
            clearCanvasGroup.alpha = 0f;
        }
        
        // ゲーム中大体0.001秒に一回このUpdate()の { } の中が自動的に実行される。
        private void Update()
        {
            // Input.GetMouseButton(0)はUpdate(){ }の中に書いてあると
            // マウスでどこでもいいので左クリックされた瞬間のみtrueになる。
            // つまり if (Input.GetMouseButtonDown(0)){ }と書くと
            // { } の中に「左クリックされた瞬間」に行いたい処理が書ける。
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("左クリックされたよ");

                // 連打に必要な回数を減らす
                _lastClickNum = _lastClickNum - 1;
                
                // 真ん中のテキストを更新する
                // テキストを更新したいときは
                // text.text = $"表示したい文字列{ここに表示したい変数の名前を書く}"
                text.text = $"後{_lastClickNum}回左クリック連打！！";
            }
            
            
            // もし_lastClickNumが0回になったら
            // { } にクリアの処理を書く。
            if (_lastClickNum == 0)
            {
                // このClear()という関数を呼ぶと、ゲームをクリアしたことにできる。
                // ちなみにGameOver()という関数を呼ぶと、ゲームを失敗したことにできる。
                Clear();
                
                // 「クリア」というテキストをはじめ非表示にしておく
                // clearCanvasGroup.alphaに0～1を入れることでどのくらいの濃さで表示するか変更できる
                // つまりclearCanvasGroup.alpha = 1f; と書くと完全に表示状態にできる。
                clearCanvasGroup.alpha = 1f;
            }
        }
    }
}