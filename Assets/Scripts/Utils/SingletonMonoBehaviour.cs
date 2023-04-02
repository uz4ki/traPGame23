using UnityEngine;
using System;

namespace Script.Utils
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour{

        private static T _instance;
        public static T Instance
        {
            get{
                if (_instance == null) {
                    Type t = typeof(T);

                    _instance = (T)FindObjectOfType (t);
                    if (_instance == null) {
                        Debug.LogError (t + " をアタッチしているGameObjectはありません");
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake(){
            CheckInstance();
        }

        protected bool CheckInstance(){
            if (_instance == null) {
                _instance = this as T;
                return true;
            } else if (Instance == this) {
                return true;
            }
            Destroy (this);
            return false;
        }
    }
}