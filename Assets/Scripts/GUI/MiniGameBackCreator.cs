using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace GUI
{
    public class MiniGameBackCreator : MonoBehaviour
    {
        [SerializeField] private Image[] frameImages;
        [SerializeField] private Image[] backImages;
        [SerializeField] private MiniGameBackInfo miniGameBackInfo;

        public void SetObjectParams()
        {
            foreach (var image in frameImages)
            {
                image.rectTransform.sizeDelta = miniGameBackInfo.size;
            }

            foreach (var image in backImages)
            {
                image.color = miniGameBackInfo.color;
            }
        }
    }
    
    [CustomEditor(typeof(MiniGameBackCreator))]//拡張するクラスを指定
    public class MiniGameBackCreatorScriptEditor : Editor {

        /// <summary>
        /// InspectorのGUIを更新
        /// </summary>
        public override void OnInspectorGUI(){
            //元のInspector部分を表示
            base.OnInspectorGUI ();

            //targetを変換して対象を取得
            var miniGameBackCreator = target as MiniGameBackCreator;

            //PrivateMethodを実行する用のボタン
            if (GUILayout.Button("Set")){
                //SendMessageを使って実行
                miniGameBackCreator!.SetObjectParams();
            }

        }

    }  
}
