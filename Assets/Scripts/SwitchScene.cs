using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("Editor_scene");
    }
}
