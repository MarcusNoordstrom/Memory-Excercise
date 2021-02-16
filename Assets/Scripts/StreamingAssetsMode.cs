using System;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class StreamingAssetsMode : MonoBehaviour {
    UnityWebRequest uwr;

    public Shader skyboxShader;
    
    void Start() {
        StartCoroutine(LoadSkybox());
    }

    static string GetFileLocation(string fileName) { 
        return Application.streamingAssetsPath + "/" + fileName; 
    }

    IEnumerator LoadSkybox() {
        using (uwr = UnityWebRequestTexture.GetTexture(GetFileLocation("skybox0.png"))) {
            yield return uwr.SendWebRequest();
            Material mat = new Material(skyboxShader);
            
            Camera.main.GetComponent<Skybox>().material = mat;
            
            //This works, if we put it to a RawImage we get the skybox picture. But since that's not an actual SkyBox, it's not properly implemented.
            //I will skip this for now, but i understand how Streaming Assets work.
        } 
    }
}