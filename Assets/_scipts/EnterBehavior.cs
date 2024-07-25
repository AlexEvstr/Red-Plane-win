using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBehavior : MonoBehaviour
{
    [SerializeField] private GameObject[] _planes;
    private void Start()
    {
        Time.timeScale = 1;
        for (int i = 0; i < _planes.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("planeSkin", 0))
            {
                _planes[i].SetActive(true);
            }
        }
        StartCoroutine(GoToHome());
    }

    private IEnumerator GoToHome()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Home");
    }
}