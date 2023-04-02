using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class MiniGameLoader : MonoBehaviour
    {
        public List<String> sceneNameList;
        private List<AsyncOperation> _loadedScenes = new List<AsyncOperation>();

        private Scene _activeScene;

        private void Start()
        {
            StartCoroutine("LoadScenes");
        }

        private IEnumerator LoadScenes()
        {
            foreach (var sceneName in sceneNameList)
            {
                var loadedScene = SceneManager.LoadSceneAsync("Scenes/" + sceneName, LoadSceneMode.Additive);
                loadedScene.allowSceneActivation = false;
                _loadedScenes.Add(loadedScene);
            }

            var flg = true;
            while (flg)
            {
                foreach (var asyncLoad in _loadedScenes)
                {
                    if (asyncLoad.progress < 0.9f) yield return null;
                    flg = false;
                }
            }
            
            Debug.Log("LoadComplete!");
        }

        public void UnloadScene()
        {
            SceneManager.UnloadSceneAsync(_activeScene.name);
            sceneNameList.RemoveAt(0);
            _loadedScenes.RemoveAt(0);
        }
        
        public void StartScene()
        {
            Debug.Log(!_activeScene.isLoaded);
            
            _activeScene = SceneManager.GetSceneByName(sceneNameList[0]);
            _loadedScenes[0].allowSceneActivation = true;
        }
    }
}
