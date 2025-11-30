using UnityEngine;

public class LoadSceneButton : MonoBehaviour
{
    public AudioClip BackgroundMusic;
    public string LoadSceneName;

    public void OnClickLoadScene()
    {
       
        if (BackgroundMusic != null)
            SoundManager.Instance.PlayMusic(BackgroundMusic);

        LoadSceneManager.Instance.LoadNewScene(LoadSceneName);
    }
}
