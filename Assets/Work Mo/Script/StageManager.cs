using UnityEngine;
using UnityEngine.SceneManagement;

public enum Estage { Stage1, Stage2, Stage3 }
public class StageManager : MonoBehaviour
{
    private int enemyCount;
    public Estage stage;

    private void Start()
    {
        // �V�[�����̂��ׂĂ� "Enemy" �^�O�̕t�����I�u�W�F�N�g�𐔂���
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // �G���|���ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    public void OnEnemyDefeated()
    {
        enemyCount--;

        // ���ׂĂ̓G���|���ꂽ��N���A�V�[���Ɉړ�
        if (enemyCount <= 0)
        {
            LoadClearScene();
        }
    }

    // �N���A�V�[���Ɉړ����郁�\�b�h
    private void LoadClearScene()
    {
        switch (stage)
        {
            case Estage.Stage3:
                SceneManager.LoadScene("ClearScene"); // "ClearScene"�̓N���A��ʂ̃V�[����
                break;
        }

    }
}