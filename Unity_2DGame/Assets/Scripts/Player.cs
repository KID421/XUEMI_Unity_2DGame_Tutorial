using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator aniPlayer;
    private SpriteRenderer sprPlayer;
    private float hp = 100;
    private float hpMax;
    private Image hpBar;
    private bool dead;
    private GameManager gm;

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

    /// <summary>
    /// 死亡方法：死亡動畫、關閉腳本
    /// </summary>
    private void Dead()
    {
        aniPlayer.SetTrigger("死亡觸發");    // 動畫.設定觸發("參數名稱")
        this.enabled = false;               // 關閉腳本
        dead = true;                        // 已經死亡
        gm.GameOver();
    }

    private void Start()
    {
        aniPlayer = GetComponent<Animator>();
        sprPlayer = GetComponent<SpriteRenderer>();
        hpBar = GameObject.Find("血條").GetComponent<Image>();
        gm = FindObjectOfType<GameManager>();

        hpMax = hp;
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dead) return;                   // 如果 死亡 跳出

        if (collision.tag == "陷阱")        // 如果 碰到物件.標籤 為 "陷阱"
        {
            hp -= 20;                       // 血量 -= 20
            hpBar.fillAmount = hp / hpMax;  // 血條.長度 = 血量 / 血量最大值

            if (hp <= 0) Dead();            // 如果 血量 <= 0 呼叫死亡方法
        }

        if (collision.tag == "櫻桃")        // 如果 碰到物件.標籤 為 "櫻桃"
        {
            hp += 5;                        // 血量 -= 20
            hp = Mathf.Clamp(hp, 0, hpMax); // 數學.夾住(血量，0，血量最大值)
            hpBar.fillAmount = hp / hpMax;  // 血條.長度 = 血量 / 血量最大值
        }

        Destroy(collision.gameObject);      // 刪除(碰到物件.遊戲物件)
    }
}
