using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeparateScene : MonoBehaviour {
    public Toggle unload, gcCollect;
    
    int _currentScene;

    void Awake() {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            _currentScene += 1;
            LoadSkyboxThruScene();
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            _currentScene -= 1;
            LoadSkyboxThruScene();
        }
    }

    void LoadSkyboxThruScene() {
        if (_currentScene < 2) {
            _currentScene = 2;
        }

        if (_currentScene > 8) {
            _currentScene = 8;
        }
        
        SceneManager.LoadScene(_currentScene);
        
        if (unload.isOn) {
            Resources.UnloadUnusedAssets();
        }

        if (gcCollect.isOn) {
            GC.Collect();
        }
    }
}