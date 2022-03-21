using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonManagement : MonoBehaviour
{
    public Text myText;
    public void QuitButton()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
   public void PlayButton()
    {
        SceneManager.LoadScene("Robin");
    }
}
