using UnityEngine;

public class LearnStaticMamber : MonoBehaviour
{
    private void Start()
    {
        // 存放靜態屬性
        Cursor.visible = false;

        // 取得靜態屬性
        print(Mathf.PI);                    // 數學.圓周率
        print(Random.value);                // 隨機.值

        // 使用靜態方法
        print(Mathf.Abs(-99));              // 數學.絕對值(數值)
        print(Random.Range(100, 1000));     // 隨機.範圍(最小值，最大值)
    }

    private void Update()
    {
        print(Input.GetKeyDown("space"));
    }
}
