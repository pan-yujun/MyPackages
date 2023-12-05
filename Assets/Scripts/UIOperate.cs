using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;


public class UIOperate : MonoBehaviour
{
    public Button btn;
    
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        btn.onClick.RemoveListener(OnBtnClick);
    }

    int count = 0;
    public void OnBtnClick()
    {
        count++;
        Debug.Log("点击了按钮,创建一个prefab");
        string key = "Assets/Prefabs/wamon.prefab";
        string key1 = "Assets/Prefabs/wamon1.prefab";
        string curKey = count % 2 == 0 ? key : key1;
        Addressables.LoadAssetAsync<GameObject>(curKey).Completed += (handle) =>
        {
            // 预设物体
            GameObject prefabObj = handle.Result;
            // 实例化
            GameObject wamon = Instantiate(prefabObj,null);
            wamon.transform.localPosition = new Vector3(-(1+ count),0,0);
        };
    }
}
