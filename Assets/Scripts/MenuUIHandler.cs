using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.SetText("Best Score: " + MenuManager.Instance.bestScore);
        nameInput.text = MenuManager.Instance.playerName;
    }
    public void StartGame()
    {
        MenuManager.Instance.SavePlayerData();
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        MenuManager.Instance.SavePlayerData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
    public void SaveName()
    {
        MenuManager.Instance.playerName = nameInput.text;
    }
}
