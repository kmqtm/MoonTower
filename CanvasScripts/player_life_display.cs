using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLifeDisplay : MonoBehaviour
{
    public string life_display_text_icon = "O";
    private string life_display_text_main   = "LIFE  ";
    private string life_display_text_sub    = "";

    private TextMeshProUGUI life_count_tmpro;
    private GameObject playerObject;
    private PlayerInputAndStateManager playerInputAndStateManager;

    // Start is called before the first frame update
    void Start()
    {
        life_count_tmpro            = GetComponent<TextMeshProUGUI>();
        playerObject                = GameObject.Find("Player");
        playerInputAndStateManager  = playerObject.GetComponent<PlayerInputAndStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < playerInputAndStateManager.player_life_point; i++) 
        {
            life_display_text_sub += life_display_text_icon;
        }

        // �e�L�X�g����������
        life_count_tmpro.text     = life_display_text_main + life_display_text_sub;

        // �J��Ԃ������p�Ɍ��̃e�L�X�g�֏�����
        life_display_text_sub = "";
    }
}
