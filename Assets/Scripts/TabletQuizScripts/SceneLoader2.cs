using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // jos LoadScene()-metodia kutsutaan, vaihdetaan nykyinen scene annetuksi sceneksi
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
