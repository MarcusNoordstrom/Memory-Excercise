using System;
using UnityEngine;

public class DirectReferencing : MonoBehaviour {
    Material _skybox0;
    Material _skybox1;
    Material _skybox2;
    Material _skybox3;
    Material _skybox4;
    Material _skybox5;

    GameObject _skyBoxHolder;

    void Awake() {
        _skybox0 = Resources.Load<Material>("skybox0");
        _skybox1 = Resources.Load<Material>("skybox1");
        _skybox2 = Resources.Load<Material>("skybox2");
        _skybox3 = Resources.Load<Material>("skybox3");
        _skybox4 = Resources.Load<Material>("skybox4");
        _skybox5 = Resources.Load<Material>("skybox5");
    }

    void Start() {
        CreateSkybox(_skybox0);
        
    }

    void CreateSkybox(Material skybox) {
        Destroy(_skyBoxHolder);
        _skyBoxHolder = new GameObject();
        _skyBoxHolder.AddComponent<Skybox>().material = skybox;
        RenderSettings.skybox = _skyBoxHolder.GetComponent<Skybox>().material;
    }
}
