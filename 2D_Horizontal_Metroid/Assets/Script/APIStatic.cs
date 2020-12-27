using UnityEngine;
/// <summary>
/// 認識API 靜態 Static
/// </summary>
public class APIStatic : MonoBehaviour
{
    void Start()
    {
        #region 靜態屬性存取
        //屬性
        //取得靜態屬性
        //語法
        //類別名稱.靜態屬性
        print("隨機值:" + Random.value);
        print("拍:" + Mathf.PI);

        //設定靜態屬性
        //語法
        //類別名稱.靜態屬性 = 值;

        //指標.可見 =
        Cursor.visible = false;

        //如果有 Read Only 不能設定 - 唯獨
        //Time.deltaTime = 0.5f; //錯誤

        Time.timeScale = 2;
        #endregion

        #region 使用靜態方法
        //使用 靜態方法
        //語法:
        //類別名稱.靜態方法(對應引數)
        print("隨機值介於 100 - 500:" + Random.Range(100, 500));

        int number = Mathf.Abs(-99);
        print("正數" + number);
        #endregion

        #region 練習
        print("攝影機數量" + Camera.allCamerasCount);
        print("2D 的重力大小" + Physics2D.gravity);
        Physics2D.gravity = new Vector2(0, -20);
        Application.OpenURL("https://unity.com/");
        print("9.999去小數點" + Mathf.Floor(9.999f));
        print("兩點的距離:" + Vector3.Distance(new Vector3(1,1,1), new Vector3(22,22,22)));
        #endregion
    }
    private void Update()
    {
        #region 練習
        print("是否輸入任意鍵" + Input.anyKeyDown);
        //print("遊戲時間" + Time.time);
        print("是否輸入空白鍵" + Input.GetKeyDown("space"));
        #endregion
    }
}
