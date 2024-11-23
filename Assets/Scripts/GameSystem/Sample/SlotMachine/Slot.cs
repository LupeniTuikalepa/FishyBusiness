namespace FishyBusiness.GameSystem.Sample
{
    public class Slot : Game<SlotContext>
    {
        public override void Begin(ref SlotContext context)
        {
            if (context.Content.GetResult(out bool slotResult))
            {
                GameManager.Instance.StopGame(this, slotResult);
            }
        }

        public override bool Refresh(ref SlotContext context)
        {
            return false;
        }

        public override void End(ref SlotContext context, bool isSucess)
        {
            context.Content.ShowResult(isSucess, context.Player, context.BetAmount);
        }
    }
}