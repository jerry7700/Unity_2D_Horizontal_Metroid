using UnityEngine;

public class Car : MonoBehaviour
{
    #region 練習欄位
    //單行註解:不會被程式讀取
    //欄位語法
    //修飾詞 類型 名稱

    //四大類型
    //整數 int
    //浮點數 float
    //字串 string
    //布林值 bool

    //修飾詞
    //私人:不會顯示 private
    //公開:會顯示 public

    //指定符號 = 

    //欄位屬性
    //語法
    //[屬性名稱("字串或對應的值")]
    //Header 標題
    //Tooltip 懸浮式
    //Range 範圍
    [Header("這是汽車高度")]
    [Range(1, 10)]
    public int height = 5;
    [Tooltip("這是汽車的重量,單位是頓")]
    public float weight = 5.5f;
    [Header("這是汽車的品牌")]
    public string brand = "BMW";
    [Header("汽車是否有天窗")]
    //是 = true;
    //否 = false;
    public bool hasWindow = true;
    //其他類型
    //顏色 color

    public Color mycolor;
    public Color red = Color.red;
    public Color bule = Color.blue;
    public Color mycolor1 = new Color(0.3f, 0.6f, 0.1f);//RGB
    public Color mycolor2 = new Color(0.5f, 0.8f, 0.5f, 7.6f);//RGB透明度

    //座標 向量 2-4
    public Vector2 v2Zero = Vector2.zero;
    public Vector2 v2one = Vector2.one;
    public Vector2 v2A = new Vector2(9, 10);

    public Vector3 v3A = new Vector3(1, 2, 3);
    public Vector4 v4A = new Vector4(1, 2, 3, 4);

    //圖片與音效
    public Sprite picture;
    public AudioClip sound;

    //遊戲物件 與 元件
    //遊戲物件:儲存階層面版內的物件與預製物
    public GameObject objA;
    public GameObject objB;

    //元件:屬性面版上可摺疊的元件
    public Transform tra;
    public Camera cam;
    #endregion
    #region 練習方法
    //欄位語法
    //修飾詞 類型 名稱 (指定 值)

    //方法語法
    //修飾詞 回傳值 名稱 () {程式區塊,陳述式,演算法}

    //viod 無回傳:呼叫此方法後不會傳回任何資料
    //自訂方法
    //不會執行,必須要呼叫才會執行
    private void Test()
    {
        //輸出 方法
        print("你好~");
    }
    //傳回類型 int
    //必須傳回 整數資料
    private int Ten()
    {
        //傳回
        return 10;
    }
    private float fl()
    {
        //傳回 
        return 5.5f;
    }
    private string Name()
    {
        return "jerryfu7700fu";
    }
    //維護擴充性
    /// <summary>
    /// 開車方法
    /// </summary>
    /// <param name="direction">開車方向</param>
    /// <param name="sound">開車音效</param>
    /// <param name="speed">開車速度</param>
    private void Drive(string direction, string sound, int speed)
    {
        print("開車方向:" + direction);
        print("開車音效:" + sound);
        print("開車速度:" + speed);
    }

    /// <summary>
    /// 開啟雨刷
    /// </summary>
    /// <param name="sound">雨刷聲音</param>
    /// <param name="speed">雨刷速度</param>
    /// 參數預設值:選填式參數
    /// 選填式參數必須要寫在右邊
    private void OpenBrush(string sound,int count = 2,int speed = 50)
    {
        print("開雨刷");
        print("雨刷聲音:" + sound);
        print("雨刷速度:" + speed);
        print("雨刷數量:" + count);
    }
    #endregion 

    //名稱藍色:事件
    //在特點時間點會執行的方法
    //開始事件:遊戲開始時執行一次
    private void Start()
    {
        //使用欄位
        //取得 Get
        print("品牌:" + brand);
        print("高度:" + height);
        //設定 Set
        hasWindow = false;
        weight = 5.5f;
        //呼叫方法
        //方法名稱();
        Test();

        //回傳方法使用方式
        // 1.直接當作回傳類型資料使用
        print("整數:" + Ten());
        print("浮點數:" + fl());
        // 2.儲存在區域變數內
        //區域變數:在事件或方法內可使用的欄位
        //僅限於此括號內使用
        string myName = Name();
        print(myName);

        Drive("後面","蹦蹦蹦",100);

        OpenBrush("莎莎");
        //指定預設值參數 參數名稱: 值
        OpenBrush("莎莎",speed: 500);
    }
}
