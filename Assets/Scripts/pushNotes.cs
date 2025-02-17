using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushNotes : MonoBehaviour
{
    float moveSpeed = 5.0f; // クラス内に変数を定義
    public float pushPosition;

    private RectTransform rectTransform;

    public static int pushCount_Great = 0;
    public static int pushCount_Good = 0;
    public static int pushCount_Miss = 0;

    [SerializeField]
    private SoundManager soundManager; //サウンドマネージャー

    void Start()
    {
        // RectTransform コンポーネントを取得
        rectTransform = GetComponent<RectTransform>();//アスペクト比を固定させているためRectTransformを使う

        Debug.Log("Anchored Position: " + rectTransform.anchoredPosition.x);
        Debug.Log("World Position: " + rectTransform.position);

    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);//ノーツの移動

        if (Input.GetKey(KeyCode.J) &&  -875 <= rectTransform.anchoredPosition.x && rectTransform.anchoredPosition.x <= -845)//判定
        {

            OnClickButton_Great();
        }
        else if (Input.GetKey(KeyCode.J) && -890 <= rectTransform.anchoredPosition.x && rectTransform.anchoredPosition.x <= -830)
        {

            OnClickButton_Good();
        }
        else if (Input.GetKey(KeyCode.J) && rectTransform.anchoredPosition.x <= -820)//早いミス
        {
            Miss();
        }
        else if (rectTransform.anchoredPosition.x <= - 900)//遅いミス
        {
            Miss();
        }


    }

    void OnClickButton_Great()
    {

        Debug.Log("Push ,X Position: " + this.rectTransform.anchoredPosition.x + " Judgemnt_Great");

        pushCount_Great++;

        pushPosition = transform.position.x;
        // ここでエフェクトを出す(音及び画面)

        Destroy(this.gameObject);//ノーツ削除

        if (pushPosition < 0)
        {
            pushPosition *= -1;
        }

    }

    void OnClickButton_Good()
    {

        Debug.Log("Push ,X Position: " + this.rectTransform.anchoredPosition.x + " Judgemnt_Good");

        pushCount_Good++;

        pushPosition = transform.position.x;
        // ここでエフェクトを出す(音及び画面)

        Destroy(this.gameObject);//ノーツ削除

        if (pushPosition < 0)
        {
            pushPosition *= -1;
        }

    }

    void Miss()
    {

        Debug.Log("Push ,X Position: " + this.rectTransform.anchoredPosition.x + " Judgemnt_Miss");

        pushCount_Miss++;

        pushPosition = transform.position.x;
        // ここでエフェクトを出す(音及び画面)

        Destroy(this.gameObject);//ノーツ削除

        if (pushPosition < 0)
        {
            pushPosition *= -1;
        }
    }

}