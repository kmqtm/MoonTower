using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverMenu : MonoBehaviour
{
    public TextMeshProUGUI restart_button;
    public TextMeshProUGUI back_to_title_button;

    private TextMeshProUGUI[] title_menu_buttons_array;
    private int selected_button_number;

    // �{�^���̗񋓌^
    private enum ButtonType
    {
        kRestartButton,    // 0
        kBackToTitleButton, // 1
    }

    // Start is called before the first frame update
    void Start()
    {
        title_menu_buttons_array = new TextMeshProUGUI[2];
        title_menu_buttons_array[0] = restart_button;
        title_menu_buttons_array[1] = back_to_title_button;

        // �����I���{�^����ݒ�
        selected_button_number = (int)ButtonType.kRestartButton;
        UpdateButtonState();
    }

    // Update is called once per frame
    void Update()
    {
        SelectButton();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ExecuteButtons();
        }
    }

    void SelectButton()
    {
        // �����
        if (Input.GetKeyDown(KeyCode.UpArrow) && selected_button_number != 0)
        {
            selected_button_number = selected_button_number - 1;
        }
        // ������
        else if (Input.GetKeyDown(KeyCode.DownArrow) && selected_button_number != 1)
        {
            selected_button_number = selected_button_number + 1;
        }

        UpdateButtonState();
    }

    void UpdateButtonState()
    {
        // ���ׂẴ{�^���𔖈Â�����
        restart_button.color = Color.gray;
        back_to_title_button.color = Color.gray;

        // �I�𒆂̃{�^�������𖾂邭����
        title_menu_buttons_array[selected_button_number].color = Color.yellow;
    }

    void ExecuteButtons()
    {
        // ���s�����֐�
        switch (selected_button_number)
        {
            case (int)ButtonType.kRestartButton:
                // �Q�[���V�[���֑J��
                SceneManager.LoadScene("GameStageScene");
                break;
            case (int)ButtonType.kBackToTitleButton:
                SceneManager.LoadScene("TitleScene");
                break;
        }
    }
}
