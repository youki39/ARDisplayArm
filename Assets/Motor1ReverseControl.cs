// https://docs.unity3d.com/Manual/UnityWebRequest.html

using UnityEngine;
using System.Collections;
// 5.4以降ではこちら
using UnityEngine.Networking;

public class Motor1ReverseControl : MonoBehaviour
{
    protected virtual void Start() => StartCoroutine(Text);

    private IEnumerator Text
    {
        get
        {
            UnityWebRequest request = UnityWebRequest.Get("http://192.168.8.126:8080/api/rotate/motor1/rad/-0.15");
            // 下記でも可
            // UnityWebRequest request = new UnityWebRequest("http://example.com");
            // methodプロパティにメソッドを渡すことで任意のメソッドを利用できるようになった
            // request.method = UnityWebRequest.kHttpVerbGET;

            // リクエスト送信
            yield return request.Send();

            // 通信エラーチェック
            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                if (request.responseCode == 200)
                {
                    // UTF8文字列として取得する
                    string text = request.downloadHandler.text;

                    // バイナリデータとして取得する
                    byte[] results = request.downloadHandler.data;
                }
            }
        }
    }
}