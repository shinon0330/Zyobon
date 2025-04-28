using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // 衝突した際に死ぬ対象を指定（例えば、敵や障害物など）
    public string targetTag = "Enemy";
    public float resetDelay = 2f;

    int life = 3;

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのタグが指定したものと一致した場合
        if (collision.gameObject.CompareTag(targetTag))
        {
            // 死ぬ処理（例えば、ゲームオーバー）
            Die();
            life = life - 1;

        }
    }

    void Die()
    {
        // ここで死ぬ処理を記述（ゲームオーバー、アニメーション、非アクティブ化など）
        Debug.Log("You Died!");

        // 例: このオブジェクトを非アクティブにする
        gameObject.SetActive(false);

        // 例: ゲームオーバー画面を表示するなどの処理も追加できます

        if (life == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            // シーンをリセットする処理
            Invoke("ResetScene", resetDelay);  // 指定した遅延後にResetSceneメソッドを呼び出す
            void ResetScene()
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);// 現在のシーンを再読み込み

            }
        }

    }
}
