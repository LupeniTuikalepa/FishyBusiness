using FishyBusiness.GameSystem.Interfaces;

namespace FishyBusiness.GameSystem
{
    public abstract class MiniGame<T> : IMiniGame 
        where T : IMiniGameContext
    {
        public abstract void Begin(ref T context);
        public abstract bool Refresh(ref T context);
        public abstract void End(ref T context);
    }
}