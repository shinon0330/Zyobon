using UnityEngine;
using UnityEngine.SceneManagement; // シーンのリロードや切り替えに必要

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // ぶつかったオブジェクトのタグが"Enemy"だったらゲームオーバー
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("ゲームオーバー！");
            GameOver();
        }
    }

    void GameOver()
    {
        // 例えばタイトル画面に戻す場合
        // SceneManager.LoadScene("TitleScene");

        // ここでは単純にリトライ（同じシーンを再読み込み）
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

