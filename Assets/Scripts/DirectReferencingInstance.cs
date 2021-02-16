using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectReferencingInstance : MonoBehaviour {
    
    int _currentSkybox;
    List<GameObject> _cams = new List<GameObject>();
    public Toggle unload, gcCollect;

    void Start() {
        for (var i = 0; i < 6; i++) {
            CreateCameraWithSkybox(Resources.Load<Material>($"skybox{i}"), $"Skybox" + $"{i}");
        }
        _currentSkybox = 0;
        DoDirectReferencingInstance();
    }
    
    void CreateCameraWithSkybox(Material skybox, string thisName) {
        var cam = new GameObject();
        cam.AddComponent<Camera>();
        cam.AddComponent<Skybox>().material = skybox;
        cam.name = thisName;
        _cams.Add(cam);
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            _currentSkybox += 1;
            DoDirectReferencingInstance();
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            _currentSkybox -= 1;
            DoDirectReferencingInstance();
        }
    }
    
    void DoDirectReferencingInstance() {
        if (_currentSkybox < 0) {
            _currentSkybox = 0;
        }
    
        if (_currentSkybox > 5) {
            _currentSkybox = 5;
        }
        ToggleSkybox(_currentSkybox);
    }
    
    void ToggleSkybox(int i) {
        for (var x = 0; x < _cams.Count; x++) {
            _cams[x].SetActive(false);
            if (x == i) {
                _cams[x].SetActive(true);
            }
        }

        if (unload.isOn) {
            Resources.UnloadUnusedAssets();
        }
    
        if (gcCollect.isOn) {
            GC.Collect();
        }
    }
}