using FishyBusiness.GameSystem.Interfaces;

namespace FishyBusiness.GameSystem.Sample
{
    public class Slot : MiniGame<SlotContext>
    {
        public override void Begin(ref SlotContext context)
        {
            context.Content.StartSlotMachine(context);
            context.status = GameStatus.Pending;
        }

        public override bool Refresh(ref SlotContext context)
        {
            if (context.Content.GetResult(out bool slotResult))
            {
                context.status = slotResult ? GameStatus.Success : GameStatus.Failure;
            }
            
            return context.status != GameStatus.Pending;
        }

        public override void End(ref SlotContext context)
        {
            context.Content.ShowResult(context);
            context.status = GameStatus.None;
        }
    }
}