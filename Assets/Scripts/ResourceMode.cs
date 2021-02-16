using System;
using UnityEngine;
using UnityEngine.UI;

public class ResourceMode : MonoBehaviour {

    int _currentSkybox;
    GameObject _currentSkyboxGameObject;
    public Toggle unload, gcCollect;

    void Start() {
        _currentSkybox = 0;
        CreateSkybox();
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            _currentSkybox += 1;
            CreateSkybox();
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            _currentSkybox -= 1;
            CreateSkybox();
        }
    }

    void CreateSkybox() {
        if (_currentSkybox < 0) {
            _currentSkybox = 0;
        }

        if (_currentSkybox > 5) {
            _currentSkybox = 5;
        }

        if (_currentSkyboxGameObject != null) {
            Destroy(_currentSkyboxGameObject);
        }
        
        _currentSkyboxGameObject = Instantiate(Resources.Load<GameObject>($"Prefabs/Skybox{_currentSkybox}"));
        
        if (unload.isOn) {
            Resources.UnloadUnusedAssets();
        }

        if (gcCollect.isOn) {
            GC.Collect();
        }
    }
}