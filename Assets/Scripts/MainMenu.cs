using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Indholder funktionaliteten til "PlayButton", som skifter scene til "GameScene"
   public void PlayGame ()
    {
        SceneManager.LoadScene("GameScene"); 
    }
    //Indholder funktionaliteten til "QuitButton", som lukker spillet ned (Bruger "Debug" til at teste, at knappen virker)
    public void QuitGame ()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}
