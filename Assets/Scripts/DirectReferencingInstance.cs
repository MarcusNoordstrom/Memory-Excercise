using System;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class DirectReferencingInstance : MonoBehaviour {
    
    int _currentSkybox;
    public Toggle unload, gcCollect;

    void Start() {
        _currentSkybox = 0;
        DoDirectReferencingInstance();
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

        LoadSkyBox(Resources.Load<Material>($"skybox{_currentSkybox}"), unload.isOn, gcCollect.isOn);
    }

    void LoadSkyBox(Material skybox, bool unload, bool gcCollect) {

        RenderSettings.skybox = skybox;
        
        if (unload) {
            Resources.UnloadUnusedAssets();
        }

        if (gcCollect) {
            GC.Collect();
        }
    }
}