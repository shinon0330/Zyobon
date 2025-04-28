using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // �Փ˂����ۂɎ��ʑΏۂ��w��i�Ⴆ�΁A�G���Q���Ȃǁj
    public string targetTag = "Enemy";
    public float resetDelay = 2f;

    int life = 3;

    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O���w�肵�����̂ƈ�v�����ꍇ
        if (collision.gameObject.CompareTag(targetTag))
        {
            // ���ʏ����i�Ⴆ�΁A�Q�[���I�[�o�[�j
            Die();
            life = life - 1;

        }
    }

    void Die()
    {
        // �����Ŏ��ʏ������L�q�i�Q�[���I�[�o�[�A�A�j���[�V�����A��A�N�e�B�u���Ȃǁj
        Debug.Log("You Died!");

        // ��: ���̃I�u�W�F�N�g���A�N�e�B�u�ɂ���
        gameObject.SetActive(false);

        // ��: �Q�[���I�[�o�[��ʂ�\������Ȃǂ̏������ǉ��ł��܂�

        if (life == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            // �V�[�������Z�b�g���鏈��
            Invoke("ResetScene", resetDelay);  // �w�肵���x�����ResetScene���\�b�h���Ăяo��
            void ResetScene()
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);// ���݂̃V�[�����ēǂݍ���

            }
        }

    }
}
