using FishyBusiness.GameSystem.Interfaces;

namespace FishyBusiness.GameSystem.Sample.BlackJack
{
    public class Black : Game<BlackContext>
    {
        public override void Begin(ref BlackContext context)
        {
            context.status = GameStatus.Pending;
        }

        public override bool Refresh(ref BlackContext context)
        {
            return context.status != GameStatus.Pending;
        }

        public override void End(ref BlackContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}