using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressablesMode : MonoBehaviour
{
    int _currentSkybox;
    GameObject _currentSkyboxGameObject;
    public Toggle unload, gcCollect;

    void Start() {
        _currentSkybox = 0;
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
    
    async void CreateSkybox() {
        if (_currentSkybox < 0) {
            _currentSkybox = 0;
        }

        if (_currentSkybox > 5) {
            _currentSkybox = 5;
        }

        if (_currentSkyboxGameObject != null) {
            Destroy(_currentSkyboxGameObject);
            AssetBundle.UnloadAllAssetBundles(true);
        }
        
        

        var validateWithAsync = Addressables.LoadResourceLocationsAsync($"skybox{_currentSkybox}");
        await validateWithAsync.Task;
        if (validateWithAsync.Status == AsyncOperationStatus.Succeeded) {
            if (validateWithAsync.Result.Count > 0) {
                _currentSkyboxGameObject = Instantiate(Addressables.LoadAssetAsync<GameObject>(validateWithAsync).Result);
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
