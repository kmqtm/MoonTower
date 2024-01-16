using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameoverCommentDisplay : MonoBehaviour
{
    public TextMeshProUGUI gameover_comment;

    // 文字列の配列
    private string[] gameover_comment_array = new string[]
    {
        "あきらめないで！",
        "大丈夫，まだいけるよ",
        "\"塔\"を\"踏\"破せよ なんちゃって",
        "一息入れよう",
        "休憩して再挑戦！",
        "安心して，兎がついてる",
        "どのくらい進んだ？",
        "まだまだ道のりは長い...？",
        "千里の道も一歩より",
        "焦らずゆっくり"
    };

    // Start is called before the first frame update
    void Start()
    {
        gameover_comment = GetComponent<TextMeshProUGUI>();

        // ランダムに選択
        string selected_string = GetRandomString();
        gameover_comment.text = selected_string;
    }

    // ランダムな文字列を取得する関数
    string GetRandomString()
    {
        // 配列の長さが0の場合はエラーを出力
        if (gameover_comment_array.Length == 0)
        {
            Debug.LogError("文字列の配列が空です。");
            return null;
        }

        // ランダムにインデックスを選択
        int random_index = Random.Range(0, gameover_comment_array.Length);

        // 選択されたインデックスの文字列を返す
        return gameover_comment_array[random_index];
    }
}
