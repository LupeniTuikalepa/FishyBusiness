using FishyBusiness.GameSystem.Interfaces;

namespace FishyBusiness.GameSystem
{
    public abstract class Game<T> : IGame 
        where T : IGameContext
    {
        public abstract void Begin(ref T context);
        public abstract bool Refresh(ref T context);
        public abstract void End(ref T context);
    }
}