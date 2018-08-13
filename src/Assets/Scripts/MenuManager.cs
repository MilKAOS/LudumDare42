using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public void ToGame()
    {
        SceneManager.LoadScene("MarsDefender");
    }

    public void ToPage()
    {
        Application.OpenURL("https://ldjam.com/events/ludum-dare/42/$98139");
    }
}