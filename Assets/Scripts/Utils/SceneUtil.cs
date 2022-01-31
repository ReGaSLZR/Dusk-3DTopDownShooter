using UnityEngine.SceneManagement;

namespace ReGaSLZR.Utils
{

    public static class SceneUtil
    {

        public static void RestartCurrent()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

}