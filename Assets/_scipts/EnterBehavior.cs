using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBehavior : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(GoToHome());
    }

    private IEnumerator GoToHome()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Home");
    }
}