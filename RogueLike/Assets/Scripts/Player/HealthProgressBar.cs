using UnityEngine;
namespace MagicPigGames
{
    public class HealthProgressBar : MonoBehaviour
    {
        private float _lastProgress = 0f;
        private ProgressBar _progressBar;

        public void UpdateHealth(float progress)
        {
            Debug.Log(progress);
            _lastProgress = progress;
            _progressBar.SetProgress(progress);
        }

        private void OnValidate()
        {
            if (_progressBar == null)
                _progressBar = GetComponent<ProgressBar>();
        }
    }
}

