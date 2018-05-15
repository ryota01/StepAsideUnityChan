using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ItemEndCubeにアタッチしてゴール地点手前からアイテムを生成しないようにする

public class ItemIsEnd : MonoBehaviour {

    private GameObject ItemGenerator;

    // Use this for initialization
    void Start () {

        // シーン中のItemGeneratorオブジェクトを取得
        this.ItemGenerator = GameObject.Find("ItemGenerator");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        // ItemEndCubeに接触したらItemGenerator.IsItemEndにfalseを送りアイテムの生成を止める
        if (other.gameObject.name == "unitychan")
        {
           ItemGenerator.gameObject.GetComponent<ItemGenerator>().IsItemEnd = false;
        }
    }
}
