using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {


    // DestroyCubeにアタッチして各種アイテムが画面の外に出たら消す
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag")
        {
            Destroy(other.gameObject);
        }
    }
        // Use this for initialization
        void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
