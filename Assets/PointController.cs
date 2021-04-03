using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    // 小さい星の得点（未使用）
    private float smallStarPoint = 0;

    // 大きい星の得点
    private float largeStarPoint = 100;

    // 小さい雲の得点
    private float smallCloudPoint = 10;

    // 大きい雲の得点
    private float largeCloudPoint = 40;

    // 得点
    private float stackPoint = 0;

    // 得点加算の速度
    private float pointSpead = 5;

    // 画面表示用得点
    private float displayPoint = 0;

    // 得点表示用のテキスト
    private GameObject pointTextObject;

    // Start is called before the first frame update
    void Start()
    {
        // 得点用のテキスト取得
        this.pointTextObject = GameObject.Find("PointText");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.stackPoint > 0)
        {
            this.displayPoint += this.pointSpead;

            this.pointTextObject.GetComponent<Text>().text = string.Format("{0}", this.displayPoint);
            this.stackPoint -= this.pointSpead;
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision col)
    {
        float point = 0;
        // 得点を初期設定
        if (col.gameObject.tag == "SmallStarTag")
        {
            // 小さい星の場合、得点は加算されない
            return;
        }
        else if (col.gameObject.tag == "LargeStarTag")
        {
            point = this.largeStarPoint;
        }
        else if (col.gameObject.tag == "SmallCloudTag")
        {
            point = this.smallCloudPoint;
        }
        else if (col.gameObject.tag == "LargeCloudTag")
        {
            point = this.largeCloudPoint;
        }
        // スタックに追加
        this.stackPoint += point;
    }
}
