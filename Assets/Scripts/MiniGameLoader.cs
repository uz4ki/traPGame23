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
        public List<String> sceneNameList;
        public List<(string sceneName,AsyncOperation asyncOperation)> loadedScenes = new();

        private Scene _activeScene;

        public void StartLoading()
        {
            StartCoroutine("LoadScenes");
        }

        public IEnumerator LoadScenes(int loadBatchSize = 5)
        {
            Debug.Log("LoadStart");

            var loadScenesNames = new string[loadBatchSize];
            for (var i = 0; i < loadBatchSize; i++)
            {
                var randomSceneName = sceneNameList[Random.Range(0, sceneNameList.Count)];
                sceneNameList.Remove(randomSceneName);
                var loadedScene = SceneManager.LoadSceneAsync("Games/" + randomSceneName, LoadSceneMode.Additive);
                loadedScene.allowSceneActivation = false;
                loadedScenes.Add((randomSceneName, loadedScene));
            }
            
            // ロード待ち処理
            var flg = true;
            while (flg)
            {
                foreach (var scene in loadedScenes)
                {
                    if (scene.asyncOperation.progress < 0.9f) yield return null;
                    flg = false;
                }
            }
            Debug.Log("LoadComplete!");
        }

        public void UnloadScene()
        {
            sceneNameList.Add(_activeScene.name);
            loadedScenes.RemoveAt(0);
            SceneManager.UnloadScene(_activeScene);
        }
        
        public void StartScene()
        {
            _activeScene = SceneManager.GetSceneByName(loadedScenes[0].sceneName);
            loadedScenes[0].asyncOperation.allowSceneActivation = true;
        }
    }
}
