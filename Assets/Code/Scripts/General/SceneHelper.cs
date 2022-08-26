using UnityEngine.SceneManagement;

namespace CartoonZombieVR.General
{
    public static class SceneHelper
    {
        public static void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
