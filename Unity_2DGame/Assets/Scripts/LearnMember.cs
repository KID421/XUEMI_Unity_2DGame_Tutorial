using UnityEngine;

public class LearnMember : MonoBehaviour
{
    public GameObject objA;         // 必須將物件拖拉至 Unity 屬性面板
    public GameObject objB;         // 必須將物件拖拉至 Unity 屬性面板

    private void Start()
    {
        objA.name = "測試物件A";
        print(objB.name);           // 結果為物件 B 的名稱
    }

    public Transform objC;          // 必須將物件拖拉至 Unity 屬性面板

    private void Update()
    {
        objC.Rotate(60, 0, 0);      // 結果為物件 C 會旋轉
    }
}
