using UnityEngine;

public class CreateProp : MonoBehaviour
{
    [Header("要生成的道具")]
    public GameObject prop;
    [Header("X 軸最小值")]
    public float xMin;
    [Header("X 軸最大值")]
    public float xMax;
    [Header("生成頻率"), Range(0.1f, 3f)]
    public float interval = 1;

    /// <summary>
    /// 生成道具物件
    /// </summary>
    private void CreatePropObject()
    {
        float x = Random.Range(xMin, xMax);             // 設定隨機 X 座標介於最小與最大之間
        Vector3 pos = new Vector3(x, 7, 0);             // 設定道具座標

        // 生成(道具，座標，角度)
        // Quaternion.identity 為零度角 = (0, 0, 0)
        Instantiate(prop, pos, Quaternion.identity);    // 生成道具
    }

    private void Start()
    {
        // 浮點數 r = 隨機.範圍(0，1.5f)
        float r = Random.Range(0, 1.5f);

        // 重複延遲呼叫("方法名稱"，延遲時間，重複頻率)
        InvokeRepeating("CreatePropObject", r, interval);   // 延遲 0 秒後以每 1 秒呼叫方法
    }
}
