
using UnityEngine;

public class LaernCharp : MonoBehaviour
{
    //比較預算執
    //
    public int a = 10;
    public int b = 3;

    private void Start()
    {
        print(a > b);          //true
        print(a < b);          //false
        print(a == b);         //false 等於
        print(a != b);         //true  不等於


        // 邏輯運算子
        // 並且 && shift + 7
        // 只要有一個 false 結果為 false
        print(true && true);    // true
        print(true && false);   // false
        print(false && true);   // false
        print(false && false);  // false

        // 或者 || shift + 鎮
        // 只要有一個 true 結果為 true
        print(true || true);    // true
        print(true || false);   // true
        print(false || true);   // true
        print(false || false);  // false
    }
}
