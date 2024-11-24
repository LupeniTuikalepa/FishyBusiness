using FishyBusiness.MiniGameSystem.Interfaces;

namespace FishyBusiness.MiniGameSystem
{
    public sealed class MiniGameRunner<T> : IMiniGameRunner 
        where T : IMiniGameContext
    {
        public IMiniGame MiniGame => miniGame;

        private readonly MiniGame<T> miniGame;
        private readonly IMiniGameHandler<T> handler;
        
        public MiniGameRunner(MiniGame<T> miniGame, IMiniGameHandler<T> handler)
        {
            this.miniGame = miniGame;
            this.handler = handler;
        }

        public void Begin()
        {
            T context = handler.GetContext();
            miniGame.Begin(ref context);
            
            handler.UpdateContext(context);
        }
        
        public bool Refresh()
        {
            T context = handler.GetContext();
            var result = miniGame.Refresh(ref context);
            
            handler.UpdateContext(context);
            return result;
        }
        
        public void End()
        {
            T context = handler.GetContext();
            miniGame.End(ref context);
            
            handler.UpdateContext(context);
        }
    }
}