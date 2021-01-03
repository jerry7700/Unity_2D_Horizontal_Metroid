using UnityEngine;

public class API : MonoBehaviour
{
    //修飾詞 類別 欄位
    public Transform tarA;
    public Transform Tester;
    public Camera cam;
    public SpriteRenderer sp;
    public GameObject lr;

    private void Start()
    {
        #region 非靜態
        //非靜態
        //取得:
        //欄位.屬性
        print("座標" + tarA.position);

        //設定:
        //欄位.屬性 指定 值
        Tester.position = new Vector3(2, 0, 0);

        //靜態屬性
        print("攝影機數量:" + Camera.allCameras);

        cam.backgroundColor = new Color(0.5f, 0.2f, 0.3f);
        #endregion
        #region 練習
        //取得
        print("顏色:" + sp.color);
        print("圖層:" + lr.layer);
        //設定
        sp.flipX = false;
        lr.layer = 5;
        #endregion
    }

    private void Update()
    {
        //非靜態
        //取得:
        //欄位.方法(對應的引數)
        Tester.Rotate(0, 0, 30);
        //位移(X,Y,Z,空間)
        //world 世界
        //self 區域
        Tester.Translate(0.5f, 0f, 0f, Space.World);
    }
}
