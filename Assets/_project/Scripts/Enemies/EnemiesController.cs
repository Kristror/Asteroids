namespace Enemies
{
    public class EnemiesController
    {
        public EnemiesController(EnemiesControllerFactory enemiesControllerFactory)
        {
            enemiesControllerFactory.Create();
        }
    }
    
}