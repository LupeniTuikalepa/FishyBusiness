using FishyBusiness.GameSystem.Interfaces;

namespace FishyBusiness.GameSystem
{
    public sealed class GameRunner<T> : IGameRunner 
        where T : IGameContext
    {
        public IGame Game => game;

        private readonly Game<T> game;
        private readonly IGameHandler<T> handler;
        
        public GameRunner(Game<T> game, IGameHandler<T> handler)
        {
            this.game = game;
            this.handler = handler;
        }

        public void Begin()
        {
            T context = handler.GetContext();
            game.Begin(ref context);
        }
        
        public bool Refresh()
        {
            T context = handler.GetContext();
            return game.Refresh(ref context);
        }
        
        public void End()
        {
            T context = handler.GetContext();
            game.End(ref context);
        }
    }
}