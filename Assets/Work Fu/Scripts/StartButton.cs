using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // ���ɑJ�ڂ���V�[���̖��O
    public string nextSceneName;

    // �X�^�[�g�{�^���������ꂽ�Ƃ��ɌĂ΂��
    public void OnStartButtonPressed()
    {
        // ���̃V�[���ɑJ��
        SceneManager.LoadScene(nextSceneName);
    }
}
