using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleleaveManager : MonoBehaviour
{
    [SerializeField] private Text PushEnter;
    [SerializeField] private float blinkingInterval = 0.5f;

    private void Start()
    {
        StartCoroutine(blinkingCoroutine());

        FadeController.Instance.FadeIn(
                    1.5f,
                    () =>
                    {
                        //SceneManager.LoadScene("GameClear");
                    }
                );
    }

    private void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeController.Instance.FadeOut(
                    1.5f,
                    () =>
                    {
                        SceneManager.LoadScene("TitleScene");
                    }
                );
            }
        }
    }

    private IEnumerator blinkingCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkingInterval);
            PushEnter.enabled = !PushEnter.enabled;
        }
    }

}
