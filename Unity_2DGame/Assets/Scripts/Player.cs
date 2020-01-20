using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator aniPlayer;
    private SpriteRenderer sprPlayer;

    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10;

    /// <summary>
    /// 移動方法：小恐龍左右移動、翻面與動畫
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");                  // 輸入.取得軸向("水平") - 玩家按 A 為 -1，玩家按 D 為 1，沒按為 0

        transform.Translate(speed * h * Time.deltaTime, 0, 0);  // 變形.位移(X，Y，Z)

        aniPlayer.SetBool("跑步開關", h != 0);                   // 動畫.設定布林值("參數名稱"，布林值)

        if (Input.GetKeyDown(KeyCode.A))                        // 如果 按下 A
        {
            sprPlayer.flipX = true;                             // 圖片渲染.翻面 = 勾選
        }
        if (Input.GetKeyDown(KeyCode.D))                        // 如果 按下 D
        {
            sprPlayer.flipX = false;                            // 圖片渲染.翻面 = 取消
        }
    }

    private void Start()
    {
        aniPlayer = GetComponent<Animator>();
        sprPlayer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }
}
