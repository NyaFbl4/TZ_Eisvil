namespace TZ_Eisvil
{
    public class KillEnemyTypeTask : ITask
    {
        private readonly string _description;
        private bool _isComplited;
    
        private readonly int _targetCount;
        private int _currentCount;
        private readonly EEnemyType? _specificType;
        private readonly TaskView _view;

        public KillEnemyTypeTask(int targetCount, TaskView view, EEnemyType? specificType = null)
        {
            _targetCount = targetCount;
            _view = view;
            _specificType = specificType;
        
            _description = specificType.HasValue 
                ? $"Убить {targetCount} врагов типа {specificType}" 
                : $"Убить {targetCount} врагов";
        }

        public void OnEnemyKilled(EEnemyType enemyType)
        {
            if (_specificType == null || _specificType == enemyType)
            {
                _currentCount++;
                UpdateProgress();
            }
        }

        public void UpdateProgress()
        {
            _view.UpdateView(_description, _currentCount, _targetCount);
        
            if (_currentCount >= _targetCount && !_isComplited)
            {
                _isComplited = true;
                _view.SetCompleted();
            }
        }
    }
}