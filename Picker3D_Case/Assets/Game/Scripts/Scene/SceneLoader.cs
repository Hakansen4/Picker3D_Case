using Ambrosia.EventBus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SceneWorks
{
    public class SceneLoader : MonoBehaviour
    {
        private const string levelPlayerPref = "Level";

        public static SceneLoader Instance { get; private set; }

        [SerializeField] private AssetReference[] _Levels;

        private int levelIndex = 0;
        private void Awake()
        {
            levelIndex = PlayerPrefs.GetInt(levelPlayerPref, 0);
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }
        private void Start()
        {
            LoadScene(levelIndex);
        }
        private void OnEnable()
        {
            EventBus<Event_LoadNextLevel>.AddListener(LoadNextLevel);
            EventBus<Event_RestartLevel>.AddListener(RestartLevel);
        }
        private void OnDisable()
        {
            EventBus<Event_LoadNextLevel>.RemoveListener(LoadNextLevel);
            EventBus<Event_RestartLevel>.RemoveListener(RestartLevel);
        }

        private void RestartLevel(object sender, Event_RestartLevel @event)
        {
            LoadScene(levelIndex);
        }

        private void LoadNextLevel(object sender, Event_LoadNextLevel @event)
        {
            levelIndex++;
            PlayerPrefs.SetInt(levelPlayerPref, levelIndex);
            LoadScene(levelIndex);
        }

        private void LoadScene(int index)
        {
            Addressables.LoadSceneAsync(_Levels[index % _Levels.Length], UnityEngine.SceneManagement.LoadSceneMode.Single).Completed += SceneLoadComplete;
        }
        private void SceneLoadComplete(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj)
        {
            Debug.Log(obj.Result.Scene.name + " Loaded");
        }
    }
}