using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TZ_Eisvil
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private TaskView _prefabTaskView;
        [SerializeField] private Transform _containerTaskViews;
        [SerializeField] private List<TaskView> _taskViews;

        private List<ITask> _na;

        private EnemyGlobalTracker _enemyGlobalTracker;
        private readonly List<ITask> _tasks = new();

        [Inject]
        public void Construct(EnemyGlobalTracker enemyGlobalTracker)
        {
            _enemyGlobalTracker = enemyGlobalTracker;
            
            _tasks.Add(new SurvivalTask(120f, CreateTaskView()));
            _tasks.Add(new KillEnemyTypeTask(15, CreateTaskView()));
            _tasks.Add(new KillEnemyTypeTask(10, CreateTaskView(), EEnemyType.Type1));
            
            _enemyGlobalTracker.OnDeathEnemy += HandleEnemyDeath;
        }

        private TaskView CreateTaskView()
        {
            var taskView = Instantiate(_prefabTaskView, _containerTaskViews);
            _taskViews.Add(taskView);

            return taskView;
        }

        private void HandleEnemyDeath(EnemyController enemy)
        {
            foreach (var task in _tasks.OfType<KillEnemyTypeTask>())
            {
                task.OnEnemyKilled(enemy.EnemyType);
            }
        }

        private void Update()
        {
            foreach (var task in _tasks)
            {
                task.UpdateProgress();
            }
        }

        private void OnDestroy()
        {
            _enemyGlobalTracker.OnDeathEnemy -= HandleEnemyDeath;
        } 
    }
}