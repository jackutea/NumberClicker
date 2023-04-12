namespace NumberClicker {

    public class GameManager {

        LevelTemplate levelTemplate;
        UI_Game ui_game;

        LevelEntity levelEntity;

        public GameManager() {}

        public void Inject(LevelTemplate levelTemplate, UI_Game ui_game) {
            this.levelTemplate = levelTemplate;
            this.ui_game = ui_game;
        }

        public void EnterLevel(int level) {

            bool has = levelTemplate.TryGet(level, out var tm);
            if (!has) {
                NCLog.Error("Level not found: " + level);
                return;
            }

            levelEntity = new LevelEntity();
            levelEntity.level = level;
            levelEntity.numbers = tm.Numbers;

            ui_game.Show();
            ui_game.Init(OnNumberSelected);

            bool hasAnswer = levelEntity.TryGetCurrentAnswer(out var answer);
            if (!hasAnswer) {
                NCLog.Error("Level not found: " + level);
                return;
            }

            ui_game.SetCurrentAnswer(answer);

        }

        void OnNumberSelected(int number) {

            levelEntity.RecordInput(number);
            GameResult res = levelEntity.TryCheckCorrect();
            if (res == GameResult.Correct) {
                levelEntity.TryGetCurrentAnswer(out var answer);
                ui_game.SetCurrentAnswer(answer);
            } else if (res == GameResult.Win) {

            } else if (res == GameResult.Lose) {
                // 弹窗
            }

            // 1. LevelEntity -> Record Input
            // 2. LevelEntity -> Check Complete Number
            // 3. LevelEntity -> IsCorrect

        }

    }

}