using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // กด Play
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // กด Exit
    public void ExitGame()
    {
        Debug.Log("Exit Game");

        Application.Quit();
    }
}