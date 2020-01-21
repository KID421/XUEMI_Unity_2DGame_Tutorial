using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Text textTime;
    private bool gameOver;

    [Header("結束畫面")]
    public GameObject final;

    private void Start()
    {
        textTime = GameObject.Find("時間").GetComponent<Text>();
    }

    private void Update()
    {
        UpdateTime();
    }

    /// <summary>
    /// 更新遊戲時間
    /// </summary>
    private void UpdateTime()
    {
        if (gameOver) return;
        textTime.text = "時間：" + Time.timeSinceLevelLoad.ToString("F2");
    }

    /// <summary>
    /// 遊戲結束
    /// </summary>
    public void GameOver()
    {
        gameOver = true;
        final.SetActive(true);
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void Quit()
    {
        Application.Quit();     // 應用程式.離開()
    }

    /// <summary>
    /// 重新遊戲
    /// </summary>
    public void Replay()
    {
        SceneManager.LoadScene("選單");       // 場景管理器.載入場景("場景名稱")
    }
}
