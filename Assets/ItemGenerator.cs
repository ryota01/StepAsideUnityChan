using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    // carPrefabを入れる
    public GameObject carPrefab;
    // coinPrefabを入れる
    public GameObject coinPrefab;
    // cornPrefabを入れる
    public GameObject conePrefab;
    // スタート地点
    private int startPos = -160;
    // ゴール地点
    private int goalPos = 120;
    // アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // フレーム計算用
    float span = 1.0f;
    float delta = 0;

    // Unityちゃんのオブジェクト
    public GameObject unitychan;
    // Unityちゃんの50m前にあるCube
    public GameObject ItemSpace;

    // アイテム生成用変数
    public bool IsItemEnd = true;

    // Use this for initialization
    void Start () {

        // シーン中のunitychanオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        // シーン中のItemSpaceオブジェクトを取得
        this.ItemSpace = GameObject.Find("ItemSpace");
    }

    // Update is called once per frame
    void Update()
    {

        // deltaにTime.deltaTimeを加算
        this.delta += Time.deltaTime;

        // 一定の距離ごとにアイテムを生成
        // オブジェクト:ItemEndCubeに接触したらfalseが代入されこの処理は終了する(アイテムの生成がされなくなる)
        if (IsItemEnd)

        {   // 60フレームに一回updateを実行する
            if (this.delta > this.span)
            {
                this.delta = 0;

                // 50m先にアイテムを生成する
                for (float i = unitychan.transform.position.z + 45; i <= ItemSpace.transform.position.z; i += 15)
                {
                    // どのアイテムを出すのかをランダムに設定
                    int num = Random.Range(0, 10);
                    if (num <= 1)
                    {
                        // コーンをx軸方向に一直線に生成
                        for (float j = -1; j <= 1; j += 0.4f)
                        {
                            GameObject cone = Instantiate(conePrefab) as GameObject;
                            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                        }
                    }
                    else
                    {

                        // レーンごとにアイテムを生成
                        for (int j = -1; j < 2; j++)
                        {
                            // アイテムの種類を決める
                            int item = Random.Range(1, 11);
                            // アイテムを置くz座標のオフセットをランダムに設定
                            int offsetZ = Random.Range(-5, 5);
                            // 60%コイン配置:30%車配置:10%何もなし
                            if (1 <= item && item <= 6)
                            {
                                // コインを生成
                                GameObject coin = Instantiate(coinPrefab) as GameObject;
                                coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                            }
                            else if (7 <= item && item <= 9)
                            {
                                // 車を生成
                                GameObject car = Instantiate(carPrefab) as GameObject;
                                car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                            }
                        }
                    }
                }
            }
        }
    }
}