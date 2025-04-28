using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private Text PushEnter;
    [SerializeField] private float blinkingInterval = 0.5f;

    private void Start()
    {
        StartCoroutine(blinkingCoroutine());
    }

    private void Update()
    {
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                FadeController.Instance.FadeOut(
                    1.5f,
                    () =>
                    {
                        SceneManager.LoadScene("SampleScene");
                    }
                );
            }
        }
    }

    private IEnumerator blinkingCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(blinkingInterval);
            PushEnter.enabled = !PushEnter.enabled;
        }
    }

}
