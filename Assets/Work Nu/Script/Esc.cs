using UnityEngine;
using UnityEngine.SceneManagement;

public class Esc : MonoBehaviour
{
    // �J�ڐ�̃V�[�������w��
    private string scene = "TitleScene";

    void Update()
    {
        // �G�X�P�[�v�L�[�������ꂽ�����`�F�b�N
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // �V�[�������[�h
            SceneManager.LoadScene(scene);
        }
    }
}
