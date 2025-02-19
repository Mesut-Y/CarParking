using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }
}
