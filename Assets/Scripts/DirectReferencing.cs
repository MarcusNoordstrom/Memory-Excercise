using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectReferencing : MonoBehaviour {
    public Toggle unload, gcCollect;
    int _currentSkybox;
    public List<GameObject> cams = new List<GameObject>();
    GameObject _currentSkyboxGameObject;

    //Solution 2: reference prefabs with cameras from a script in the scene. Instantiate one camera at a time.

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
        
        _currentSkyboxGameObject = Instantiate(cams[_currentSkybox]);
        
        
        if (unload.isOn) {
            Resources.UnloadUnusedAssets();
        }

        if (gcCollect.isOn) {
            GC.Collect();
        }
    }
}
