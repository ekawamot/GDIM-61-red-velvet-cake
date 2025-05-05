using UnityEngine;
using UnityEngine.SceneManagement;

public class FishGameManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FishMinigame")
        {
            // unlock & show the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible   = true;

            var fpc = FindObjectOfType<FirstPersonController>();
            if (fpc != null)
                fpc.enabled = false;
        }
    }

}
