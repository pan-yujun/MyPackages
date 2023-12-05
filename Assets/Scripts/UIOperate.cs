using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class UIOperate : MonoBehaviour
{
    public Button btn;
    public Button btn1;
    public Button btn2;
    public RawImage rawImage;


    private List<GameObject> gos = new List<GameObject>();
    private AsyncOperationHandle<GameObject> btn1Handle;
    private Texture2D tx2D;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnBtnClick);
        btn1.onClick.AddListener(OnBtn1Click);
        btn2.onClick.AddListener(OnBtn2Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        btn.onClick.RemoveListener(OnBtnClick);
        btn1.onClick.RemoveListener(OnBtn1Click);
        btn2.onClick.RemoveListener(OnBtn2Click);
    }

    int count = 0;

    /// <summary>
    /// ��������
    /// </summary>
    public void OnBtnClick()
    {
        count++;
        Debug.Log("����˰�ť,����һ��prefab");
        string key = "Assets/Prefabs/wamon.prefab";
        string key1 = "Assets/Prefabs/wamon1.prefab";
        string curKey = count % 2 == 0 ? key : key1;
        Addressables.LoadAssetAsync<GameObject>(curKey).Completed += (handle) =>
        {
            // Ԥ������
            GameObject prefabObj = handle.Result;
            // ʵ����
            GameObject wamon = Instantiate(prefabObj,null);
            wamon.name = string.Format("remoteOb_{0}",count);
            gos.Add(wamon);
            wamon.transform.localPosition = new Vector3(-(1+ count),0,0);
        };

        // ����ͼƬ
        Addressables.LoadAssetAsync<Texture2D>("Assets/Testures/img_Lrc_ShapeFX.png").Completed += (obj) =>
        {
            // Ԥ������
            tx2D = obj.Result;
            rawImage.texture = tx2D; 
        };
    }
    /// <summary>
    /// ɾ������
    /// </summary>
    public void OnBtn2Click()
    {
        foreach (var go in gos)
        {
            Debug.Log(string.Format("ɾ������:{0}",go.name));
            Destroy(go);
        }
        if (rawImage != null)
        {
            Debug.Log(string.Format("ɾ������:{0}", rawImage.gameObject.name));
            Destroy(rawImage.gameObject);
        }
    }
    /// <summary>
    /// �ͷ���Դ
    /// </summary>
    public void OnBtn1Click()
    {
        // �ͷ���Դ
        if (tx2D != null)
        { 
            Debug.Log("�ͷ���Դ");
            Addressables.Release(tx2D);
        }
    }
}
