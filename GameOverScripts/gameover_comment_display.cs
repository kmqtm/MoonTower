using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameoverCommentDisplay : MonoBehaviour
{
    public TextMeshProUGUI gameover_comment;

    // ������̔z��
    private string[] gameover_comment_array = new string[]
    {
        "������߂Ȃ��ŁI",
        "���v�C�܂��������",
        "\"��\"��\"��\"�j���� �Ȃ񂿂����",
        "�ꑧ����悤",
        "�x�e���čĒ���I",
        "���S���āC�e�����Ă�",
        "�ǂ̂��炢�i�񂾁H",
        "�܂��܂����̂�͒���...�H",
        "�痢�̓���������",
        "�ł炸�������"
    };

    // Start is called before the first frame update
    void Start()
    {
        gameover_comment = GetComponent<TextMeshProUGUI>();

        // �����_���ɑI��
        string selected_string = GetRandomString();
        gameover_comment.text = selected_string;
    }

    // �����_���ȕ�������擾����֐�
    string GetRandomString()
    {
        // �z��̒�����0�̏ꍇ�̓G���[���o��
        if (gameover_comment_array.Length == 0)
        {
            Debug.LogError("������̔z�񂪋�ł��B");
            return null;
        }

        // �����_���ɃC���f�b�N�X��I��
        int random_index = Random.Range(0, gameover_comment_array.Length);

        // �I�����ꂽ�C���f�b�N�X�̕������Ԃ�
        return gameover_comment_array[random_index];
    }
}
