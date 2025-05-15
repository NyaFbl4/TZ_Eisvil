using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace TZ_Eisvil
{
    public class SurvivalTask : ITask
    {
        private readonly string _description;
        private bool _isComplited;

        private readonly float _targetTime;
        private float _currentTime;
        private readonly TaskView _view;

        public SurvivalTask(float targetTime, TaskView view)
        {
            _targetTime = targetTime;
            _view = view;

            _description = "Пробыть в игре";
        }
        
        public void UpdateProgress()
        {
            _currentTime += Time.deltaTime;
            _view.UpdateView(_description, (int)_currentTime, (int)_targetTime);
        
            if (_currentTime >= _targetTime && !_isComplited)
            {
                _isComplited = true;
                _view.SetCompleted();
            }
        }
    }
}