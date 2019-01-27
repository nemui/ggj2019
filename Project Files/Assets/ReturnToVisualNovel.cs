using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToVisualNovel : MonoBehaviour
{
    public void ReturnToVisualNovelScene()
    {
        SceneManager.LoadScene("VisualNovelPart", LoadSceneMode.Single);
    }
}
