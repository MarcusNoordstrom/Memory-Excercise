using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Switcher : MonoBehaviour {

    public Text modeText;
    int _currentMenu;

    enum Mode {
        DirectReferencingInstance, DirectReferencing, SeparateScene, Resources, StreamingAssets, AssetBundles, Addressables
    }

    Mode _currentMode;

    void Start() {
        _currentMode = Mode.DirectReferencingInstance;
        DirectReferencingInstance(_currentMenu);
    }

    void Update() {
        if (_currentMode == Mode.DirectReferencingInstance) {
            if (Input.GetKeyUp(KeyCode.RightArrow)) {
                DirectReferencingInstance(_currentMenu += 1);
            }
        
            if (Input.GetKeyUp(KeyCode.LeftArrow)) {
                DirectReferencingInstance(_currentMenu -= 1);
            }
        }
        else if (_currentMode == Mode.DirectReferencing) {
            DirectReferencing();
        }
    }

    void DirectReferencingInstance(int i) {
        modeText.text = "Current Mode: Direct Referencing Instance";
        if (i < 0) {
            i = 0;
            _currentMenu = 0;
        }

        if (i > 5) {
            _currentMode = Mode.DirectReferencing;
        }
        
        Destroy(RenderSettings.skybox);
        var skyBox = new Material((Material) AssetDatabase.LoadAssetAtPath($"Assets/Skyboxes/skybox{i}.mat", typeof(Material)));
        RenderSettings.skybox = skyBox;
    }

    void DirectReferencing() {
        Debug.Log("TEST");
    }
}