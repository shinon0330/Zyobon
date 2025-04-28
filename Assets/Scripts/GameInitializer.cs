using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        if(FadeController.Instance != null)
        {
            FadeController.Instance.FadeIn(1f, null);
        }
    }
}
