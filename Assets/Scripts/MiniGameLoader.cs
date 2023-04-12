using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Script
{
    public class MiniGameLoader : MonoBehaviour
    {
        [SerializeField] private int loadBatchSize;
        public List<String> sceneNameList;
        private List<(string sceneName,AsyncOperation asyncOperation)> _loadedScenes = new();

        private Scene _activeScene;

        public void StartLoading()
        {
            StartCoroutine("LoadScenes");
        }

        public IEnumerator LoadScenes()
        {
            var loadScenesNames = new string[loadBatchSize];
            for (var i = 0; i < loadBatchSize; i++)
            {
                var randomSceneName = sceneNameList[Random.Range(0, sceneNameList.Count)];
                sceneNameList.Remove(randomSceneName);
                var loadedScene = SceneManager.LoadSceneAsync("Scenes/" + randomSceneName, LoadSceneMode.Additive);
                loadedScene.allowSceneActivation = false;
                _loadedScenes.Add((randomSceneName, loadedScene));
                Debug.Log(_loadedScenes[0]);
            }
            
            // ロード待ち処理
            var flg = true;
            while (flg)
            {
                foreach (var scene in _loadedScenes)
                {
                    if (scene.asyncOperation.progress < 0.9f) yield return null;
                    flg = false;
                }
            }
            Debug.Log("LoadComplete!");
        }

        public void UnloadScene()
        {
            SceneManager.UnloadSceneAsync(_activeScene.name);
         //   sceneNameList.RemoveAt(0);
            _loadedScenes.RemoveAt(0);
        }
        
        public void StartScene()
        {
            Debug.Log(!_activeScene.isLoaded);
            
            _activeScene = SceneManager.GetSceneByName(_loadedScenes[0].sceneName);
            _loadedScenes[0].asyncOperation.allowSceneActivation = true;
        }
    }
}
