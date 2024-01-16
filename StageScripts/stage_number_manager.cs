using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageNumberManager : MonoBehaviour
{
    public int stage_number = 1;

    // �X�e�[�W���Q�Ɗ֐�
    public int GetStageNumber()
    {
        return stage_number;
    }

    // �X�e�[�W���X�V
    public void IncrementStageNumber()
    {
        stage_number++;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (stage_number == 16)
        {
            SceneManager.LoadScene("EndingScene");
        }
    }
}
