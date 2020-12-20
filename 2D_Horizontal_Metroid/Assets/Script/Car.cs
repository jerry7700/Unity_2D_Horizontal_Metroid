﻿using UnityEngine;

public class Car : MonoBehaviour
{
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
    [Range(1,10)]
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
    public Color mycolor1 = new Color(0.3f,0.6f,0.1f);//RGB
    public Color mycolor2 = new Color(0.5f, 0.8f, 0.5f, 7.6f);//RGB透明度

    //座標 向量 2-4
    public Vector2 v2Zero = Vector2.zero;
    public Vector2 v2one = Vector2.one;
    public Vector2 v2A = new Vector2(9, 10);

    public Vector3 v3A = new Vector3(1, 2, 3);
    public Vector4 v4A = new Vector4(1, 2, 3,4);

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
}
