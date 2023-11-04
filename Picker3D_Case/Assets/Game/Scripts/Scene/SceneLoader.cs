using Ambrosia.EventBus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [SerializeField] private AssetReference[] _Levels;

    private int LevelIndex = 0;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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
        LoadScene(LevelIndex);
    }

    private void LoadNextLevel(object sender, Event_LoadNextLevel @event)
    {
        LevelIndex++;
        LoadScene(LevelIndex);
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
