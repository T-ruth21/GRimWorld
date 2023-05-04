using Verse.AI;
using RimWorld;
using Verse;

namespace TRuth
{
    public class MentalState_PanicFleeSpider : MentalState
    {
        private int lastInsectSeenTick = -1;
    
        protected override bool CanEndBeforeMaxDurationNow => false;
    
        public override RandomSocialMode SocialModeMax() => RandomSocialMode.Off;
    
        public override void MentalStateTick()
        {
            base.MentalStateTick();
            if (!this.pawn.IsHashIntervalTick(30))
                return;
            if (this.lastInsectSeenTick < 0 || ThoughtWorker_Arachnophobia.NearInsect(this.pawn))
                this.lastInsectSeenTick = Find.TickManager.TicksGame;
            if (this.lastInsectSeenTick < 0 || Find.TickManager.TicksGame < this.lastInsectSeenTick + this.def.minTicksBeforeRecovery)
                return;
            this.RecoverFromState();
        }
    
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<int>(ref this.lastInsectSeenTick, "lastInsectSeenTick", -1);
        }
    }
}