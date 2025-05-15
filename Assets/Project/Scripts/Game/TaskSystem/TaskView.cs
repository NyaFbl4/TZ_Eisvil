using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TZ_Eisvil
{
    public class TaskView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _progressText;
        [SerializeField] private Image _background;
        [SerializeField] private GameObject _completionMark;

        public void UpdateView(string description, int current, int target)
        {
            _descriptionText.text = description;
            _progressText.text = $"{current}/{target}";
        }
        
        public void SetCompleted()
        {
            _background.color = Color.green;
            _completionMark.SetActive(true);
        }
    }
}