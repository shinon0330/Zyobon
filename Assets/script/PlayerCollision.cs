using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���̃����[�h��؂�ւ��ɕK�v

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // �Ԃ������I�u�W�F�N�g�̃^�O��"Enemy"��������Q�[���I�[�o�[
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("�Q�[���I�[�o�[�I");
            GameOver();
        }
    }

    void GameOver()
    {
        // �Ⴆ�΃^�C�g����ʂɖ߂��ꍇ
        // SceneManager.LoadScene("TitleScene");

        // �����ł͒P���Ƀ��g���C�i�����V�[�����ēǂݍ��݁j
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

