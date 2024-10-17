using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject helpMenu;
    public GameObject level;

    public bool isMenu = true;

    public void Start () {
        if (isMenu) {
            FindObjectOfType<AudioManager> ().StopAll ();
		    FindObjectOfType<AudioManager> ().Play ("Menu");
        }
    }

    public void Button_Play () {
        level.SetActive (true);
        level.GetComponent<LevelChanger> ().FadeToLevel (1);
    }

    public void Button_Help () {
        mainMenu.SetActive (false);
        helpMenu.SetActive (true);
    }

    public void Button_Quit () {
        Application.Quit ();
    }

    public void Button_Back () {
        mainMenu.SetActive (true);
        helpMenu.SetActive (false);
    }

    public void MainMenu () {
        level.SetActive (true);
        level.GetComponent<LevelChanger> ().FadeToLevel (0);
    }
}
