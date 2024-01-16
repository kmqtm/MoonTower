using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleOptionSetting : MonoBehaviour
{
    public TextMeshProUGUI player_life_setting_tmpro;
    
    private Image optionImage;
    private GameObject title;
    private TitleSound titleSound;

    // プライヤーのライフ数
    public static int player_life_num = 3;

    // Start is called before the first frame update
    void Start()
    {
        player_life_setting_tmpro = GetComponent<TextMeshProUGUI>();

        // "Option"という名前のImageを探す
        optionImage = GameObject.Find("Option").GetComponent<Image>();

        title = GameObject.Find("Title");
        titleSound = title.GetComponent<TitleSound>();
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerLifeWithKeyInput();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Optionを閉じる
            SetOptionImageActiveFalse();
        }
    }

    void SetPlayerLifeWithKeyInput()
    {
        // 右入力
        if (Input.GetKeyDown(KeyCode.RightArrow) && player_life_num != 8)
        {
            player_life_num = player_life_num + 1;

            titleSound.PlayTitleKeyInputSound();
        }
        // 左入力
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && player_life_num != 1)
        {
            player_life_num = player_life_num - 1;

            titleSound.PlayTitleKeyInputSound();
        }

        UpdatePlayerLifeSettingText();
    }

    void UpdatePlayerLifeSettingText()
    {
        player_life_setting_tmpro.text = "LIFE  ";

        for (int i = 0; i < player_life_num; i++)
        {
            player_life_setting_tmpro.text += "■";
        }
    }

    void SetOptionImageActiveFalse()
    {
        optionImage.gameObject.SetActive(false);
    }
}
