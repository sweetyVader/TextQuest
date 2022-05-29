using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private string _loadSceneName;

    private void Start()
    {
        _playButton.onClick.AddListener(PlayButtonClicked);
    }

    private void PlayButtonClicked()
    {
        _sceneLoader.LoadScene(_loadSceneName);
    }
}