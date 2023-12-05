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
        Debug.Log("����˰�ť,����һ��prefab");
        Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/wamon.prefab").Completed += (handle) =>
        {
            // Ԥ������
            GameObject prefabObj = handle.Result;
            // ʵ����
            GameObject wamon = Instantiate(prefabObj,null);
            wamon.transform.localPosition = new Vector3(-(1+ count),0,0);
        };
    }
}
