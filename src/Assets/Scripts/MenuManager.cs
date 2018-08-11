using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void ToGame()
    {
        SceneManager.LoadScene("MarsDefender");
    }
}
