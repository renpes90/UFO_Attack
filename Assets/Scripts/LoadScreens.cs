using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScreens : MonoBehaviour
{
    public bool splash = false;

    private void Start()
    {  
        if (splash == true)
        {
            StartCoroutine(ChangeScreen());
        }
    }

    IEnumerator ChangeScreen()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main");
    }

    public void goLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void goLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void goSelector()
    {
        SceneManager.LoadScene("Main");
    }

    public void goCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}