using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class StoryTextDisplay : MonoBehaviour
{
    private TextMeshProUGUI story_text_display_tmpro;
    private GameObject stageManager;
    private StageNumberManager stageNumberManager;

    // �e�L�X�g���i�[����z��
    private Dictionary<int, string> story_text_array = new Dictionary<int, string>();

    void Start()
    {
        story_text_display_tmpro = GetComponent<TextMeshProUGUI>();
        stageManager = GameObject.Find("StageManager");
        stageNumberManager = stageManager.GetComponent<StageNumberManager>();

        // ���ڃe�L�X�g���L�q
        // �����͊O���t�@�C�����Q�Ƃ���悤�ɂ�����
        story_text_array[1] = "�͂邩�́C���ɂ͐l���Z��ł��܂���";
        story_text_array[2] = "���ɂ͏\���ȐH���������C�l�X�͋Q���ɋꂵ��ł��܂���";
        story_text_array[3] = "������C�������������N�C���R�����܂�܂���";
        story_text_array[4] = "���R�͋�z�������ɂ���͂������Ă��܂���";
        story_text_array[5] = "���̊�Ղ̂悤�ȗ͂͌��Ɛl�X��L���ɂ��܂���";
        story_text_array[6] = "�������C���R�̗͂����p���悤�Ƃ���l������܂���";
        story_text_array[7] = "��Ղ̗͂���ɓ���邽�߁C�����̐l�X�������܂���";
        story_text_array[8] = "���̑����͌��ʂ𕢂��C���R�͔߂��݂܂���";
        story_text_array[9] = "�����āC���Ƀ��R�͈�̌��f�������܂���";
        story_text_array[10] = "�u���̒n�����b�܂ꂽ�C���ƌ��̖L���Ȑ�������΁v";
        story_text_array[11] = "�u�ڂ��̗͂��Ȃ��Ă��C�����Ƃ݂�Ȃ͏Ί�ŕ�点��v";
        story_text_array[12] = "��Ղ̗͂��g���C���R�͐V���Ȑ������̋߂��ɑn��";
        story_text_array[13] = "���R�ȊO�̐l�Ԃ����̐��֑���܂���";
        story_text_array[14] = "��Ղ̗͂��g���ʂ��������R�͏b�̎p�ƂȂ�";
        story_text_array[15] = "�����̖тɕ����ԐԂ����ł��̐��𒭂ߑ����܂���";
    }

    private void Update()
    {
        // �X�e�[�W���Ƃ̃e�L�X�g�\��
        story_text_display_tmpro.text = GetText(stageNumberManager.GetStageNumber());
    }

    // �w�肳�ꂽ�ԍ��̃e�L�X�g���擾���郁�\�b�h
    public string GetText(int number)
    {
        if (story_text_array.ContainsKey(number))
        {
            return story_text_array[number];
        }
        else
        {
            Debug.LogError("�w�肳�ꂽ�ԍ��̃e�L�X�g�����݂��܂���B");
            return string.Empty;
        }
    }
}

