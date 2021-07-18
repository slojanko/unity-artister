using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField]
    private bool SwitchOnAwake;
    [SerializeField]
    private string scene;

    void Awake()
    {
        if (SwitchOnAwake) {
            Switch();
        }
    }

    public void Switch()
    {
        SceneManager.LoadScene(scene);
    }
}
