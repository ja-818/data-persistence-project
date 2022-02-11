using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    public TextMeshProUGUI nameAndScoreText;
    private void Start()
    {
        GameManager.Instance.LoadHighScore();
        nameAndScoreText.text = $"{GameManager.Instance.highScore.playerName} : {GameManager.Instance.highScore.score}";
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.currentPlayerName = GameObject.Find("Text Name Player").GetComponent<TextMeshProUGUI>().text;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
