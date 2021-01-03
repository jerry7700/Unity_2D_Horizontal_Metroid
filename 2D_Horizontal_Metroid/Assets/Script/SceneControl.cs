using UnityEngine;
using UnityEngine.SceneManagement; //引用 場景管理 API

public class SceneControl : MonoBehaviour
{
    [Header("音效來源")]
    public AudioSource aud;
    [Header("按鈕音效")]
    public AudioClip soundClick;

    //1.方法要讓按鈕呼叫必須設為公開 public
    /// <summary>
    /// 開始遊戲
    /// </summary>
   public void StartGame()
    {
        //音效來源.方法(音效,音量)
        aud.PlayOneShot(soundClick);

        //延遲("名稱", 延遲秒數)
        Invoke("DelayStartGame", 1.5f);
    }

    /// <summary>
    /// 延遲開始遊戲
    /// </summary>
    private void DelayStartGame()
    {
        //2.必須將場景放在 file > Build Settings...
        //場景管理.載入場景("場景名稱")
        SceneManager.LoadScene("遊戲場景");
    }
    /// <summary>
    /// 回選單
    /// </summary>
    public void BackToMenu()
    {
        aud.PlayOneShot(soundClick);
        Invoke("DelayBackToMenu", 1.5f);
    }

    /// <summary>
    /// 延遲回選單
    /// </summary>
    public void DelayBackToMenu()
    {
        SceneManager.LoadScene("選單");
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        aud.PlayOneShot(soundClick);
        Invoke("DelayQuitGame", 1.5f);
    }

    /// <summary>
    /// 延遲離開遊戲
    /// </summary>
    public void DelayQuitGame()
    {
        //應用程式.離開遊戲()
        Application.Quit();
    }
}
