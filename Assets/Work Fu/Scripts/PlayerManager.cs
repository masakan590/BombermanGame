using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int PlayerNum;
    public int DeadPlayerNum;
    public TMP_Text gameOverText; // TextMeshPro�p��TMP_Text

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeadPlayer()
    {
        DeadPlayerNum++;
        if (DeadPlayerNum >= PlayerNum)
        {
            gameOverText.enabled = true; // �Q�[���I�[�o�[�̃��b�Z�[�W��\��
            Invoke(nameof(RestartStage), 2);
       
        }

    }


    private void RestartStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���݂̃X�e�[�W���ă��[�h
    }
}  


