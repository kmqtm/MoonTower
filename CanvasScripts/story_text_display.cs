using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class StoryTextDisplay : MonoBehaviour
{
    private TextMeshProUGUI story_text_display_tmpro;
    private GameObject stageManager;
    private StageNumberManager stageNumberManager;

    // テキストを格納する配列
    private Dictionary<int, string> story_text_array = new Dictionary<int, string>();

    void Start()
    {
        story_text_display_tmpro = GetComponent<TextMeshProUGUI>();
        stageManager = GameObject.Find("StageManager");
        stageNumberManager = stageManager.GetComponent<StageNumberManager>();

        // 直接テキストを記述
        // ここは外部ファイルを参照するようにしたい
        story_text_array[1] = "はるか昔，月には人が住んでいました";
        story_text_array[2] = "月には十分な食料が無く，人々は飢えに苦しんでいました";
        story_text_array[3] = "ある日，長い耳を持つ少年，リコが生まれました";
        story_text_array[4] = "リコは空想を現実にする力を持っていました";
        story_text_array[5] = "その奇跡のような力は月と人々を豊かにしました";
        story_text_array[6] = "しかし，リコの力を悪用しようとする人も現れました";
        story_text_array[7] = "奇跡の力を手に入れるため，多くの人々が争いました";
        story_text_array[8] = "その争いは月面を覆い，リコは悲しみました";
        story_text_array[9] = "そして，ついにリコは一つの決断を下しました";
        story_text_array[10] = "「月の地よりも恵まれた，水と光の豊かな星があれば」";
        story_text_array[11] = "「ぼくの力がなくても，きっとみんなは笑顔で暮らせる」";
        story_text_array[12] = "奇跡の力を使い，リコは新たな星を月の近くに創り";
        story_text_array[13] = "リコ以外の人間をその星へ送りました";
        story_text_array[14] = "奇跡の力を使い果たしたリコは獣の姿となり";
        story_text_array[15] = "白い体毛に浮かぶ赤い瞳でその星を眺め続けました";
    }

    private void Update()
    {
        // ステージごとのテキスト表示
        story_text_display_tmpro.text = GetText(stageNumberManager.GetStageNumber());
    }

    // 指定された番号のテキストを取得するメソッド
    public string GetText(int number)
    {
        if (story_text_array.ContainsKey(number))
        {
            return story_text_array[number];
        }
        else
        {
            Debug.LogError("指定された番号のテキストが存在しません。");
            return string.Empty;
        }
    }
}

