namespace AsteroidsGame.Warship
{
    public class WarshipStatsController
    {
        private readonly WarshipMovementModel _model;
        private readonly StatsView _statsView;

        public WarshipStatsController(WarshipMovementModel model, StatsView statsView)
        {
            _model = model;
            _statsView = statsView;

            _statsView.Stats.text = model.CurrentSpeed.ToString();
        }

        public void UpdateStats()
        {
            _statsView.Stats.text = _model.CurrentSpeed.ToString();
        }
    }
}