using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesSystem : PersistentSingleton<ScenesSystem>
{
    // Scene AR_Assistant_Scene;
    private string AR_Assistant_Scene = "AR Assistant Scene";
    public string AR_Additive_Scene;
    private async void Start()
    {
        loadSceneByName(AR_Assistant_Scene, LoadSceneMode.Additive);
        loadSceneByName(AR_Additive_Scene, LoadSceneMode.Additive);
        //loadSceneByName("Masterclass",LoadSceneMode.Additive);
        await Task.Delay(25);
        //oadSceneByName("User Interface", LoadSceneMode.Additive);
    }

    public void loadAdditiveScene()
    {
        loadSceneByName(AR_Additive_Scene, LoadSceneMode.Additive);
    }

    /// <summary>
    /// Load a scene by name if it is not already loaded. 
    /// </summary>
    /// <param name="SceneName"></param>
    /// <param name="loadSceneMode"></param>
    public void loadSceneByName(string SceneName, LoadSceneMode loadSceneMode)
    {
        if (SceneManager.GetSceneByName(SceneName).isLoaded == false) SceneManager.LoadScene(SceneName, loadSceneMode);
    }

    public void loadARScenes()
    {

    }
}