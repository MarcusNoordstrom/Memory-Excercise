using System;
using UnityEngine;
using UnityEngine.UI;

public class DirectReferencing : MonoBehaviour {
    public Toggle unload, gcCollect;
    int _currentSkybox;
    GameObject cam;
    
    void Awake() {
        cam = Camera.main.gameObject;
    }

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
        
        if (cam.GetComponent<Skybox>() != null) {
            Destroy(cam.GetComponent<Skybox>());
        }
        
        var skybox = cam.AddComponent<Skybox>();
        
        skybox.material = Resources.Load<Material>($"skybox{_currentSkybox}");
        
        if (unload.isOn) {
            Resources.UnloadUnusedAssets();
        }

        if (gcCollect.isOn) {
            GC.Collect();
        }
    }
}
