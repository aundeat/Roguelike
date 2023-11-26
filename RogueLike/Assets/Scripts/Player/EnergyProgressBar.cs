using UnityEngine;
namespace MagicPigGames
{
    public class EnergyProgressBar : MonoBehaviour
    {
        private float _lastProgress = 0f;
        private ProgressBar _progressBar;

        public void UpdateEnergy(float progress)
        {
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

