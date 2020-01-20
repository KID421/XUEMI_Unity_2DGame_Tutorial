using UnityEngine;

public class LearnOperator : MonoBehaviour
{
    public float a = 10;
    public float b = 3;

    public int c = 99;
    public int d = 1;

    private void Start()
    {
        print(a + b);  // 結果：13
        print(a - b);  // 結果：7
        print(a * b);  // 結果：30
        print(a / b);  // 結果：3.333
        print(a % b);  // 結果：1

        print(c < d);    // 結果為 false
        print(c > d);    // 結果為 true
        print(c <= d);   // 結果為 false
        print(c >= d);   // 結果為 true
        print(c == d);   // 結果為 false
        print(c != d);   // 結果為 true

        print(true && true);    // 結果為 true
        print(true && false);   // 結果為 false
        print(false && true);   // 結果為 false
        print(false && false);  // 結果為 false

        print(true || true);    // 結果為 true
        print(true || false);   // 結果為 true
        print(false || true);   // 結果為 true
        print(false || false);  // 結果為 false

        print(!true);           // 結果為 false
        print(!false);          // 結果為 true
    }
}
