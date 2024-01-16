using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class title_menu_controller : MonoBehaviour
{
    public TextMeshProUGUI game_button;
    public TextMeshProUGUI option_button;
    public TextMeshProUGUI exit_button;

    private TextMeshProUGUI[] title_menu_buttons_array;
    private int selected_button_number;
    private Image optionImage;
    private TitleSound titleSound;

    // ボタンの列挙型
    private enum ButtonType
    {
        kGameButton,    // 0
        kOptionsButton, // 1
        kExitButton     // 2
    }

    // Start is called before the first frame update
    void Start()
    {
        title_menu_buttons_array = new TextMeshProUGUI[3];
        title_menu_buttons_array[0] = game_button;
        title_menu_buttons_array[1] = option_button;
        title_menu_buttons_array[2] = exit_button;

        titleSound = GetComponent<TitleSound>();

        // "Option"という名前のImageを探す
        optionImage = GameObject.Find("Option").GetComponent<Image>();

        // Imageが存在し、アクティブな場合は非表示にする
        if (optionImage != null && optionImage.gameObject.activeSelf)
        {
            optionImage.gameObject.SetActive(false);
        }

        // 初期選択ボタンを設定
        selected_button_number = (int)ButtonType.kGameButton;
        UpdateButtonState();
    }

    // Update is called once per frame
    void Update()
    {
        if (optionImage.IsActive() == false)
        {
            SelectButton();

            if (Input.GetKeyDown(KeyCode.Return))
            {
                ExecuteButtons();
            }
        }
    }

    void SelectButton()
    {
        // 上入力
        if (Input.GetKeyDown(KeyCode.UpArrow) && selected_button_number != 0)
        {
            selected_button_number = selected_button_number - 1;

            titleSound.PlayTitleKeyInputSound();
        }
        // 下入力
        else if (Input.GetKeyDown(KeyCode.DownArrow) && selected_button_number != 2)
        {
            selected_button_number = selected_button_number + 1;

            titleSound.PlayTitleKeyInputSound();
        }

        UpdateButtonState();
    }

    void UpdateButtonState()
    {
        // すべてのボタンを薄暗くする
        game_button.color = Color.gray;
        option_button.color = Color.gray;
        exit_button.color = Color.gray;

        // 選択中のボタンだけを明るくする
        title_menu_buttons_array[selected_button_number].color = Color.yellow;
    }

    void ExecuteButtons()
    {
        // 実行される関数
        switch (selected_button_number)
        {
            case (int)ButtonType.kGameButton:
                StartGame();
                break;
            case (int)ButtonType.kOptionsButton:
                OpenOptions();
                break;
            case (int)ButtonType.kExitButton:
                ExitGame();
                break;
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameStageScene");
    }

    void OpenOptions()
    {
        optionImage.gameObject.SetActive(true);
    }

    void ExitGame()
    {
        // ゲームの終了
        Application.Quit();
    }
}
