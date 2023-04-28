using Verse;
using RimWorld;

namespace TST_PlagueGun
{
    public class Projectile_PlagueBullet : Bullet
    {
        public Grimworld.ModExtension_PlagueBullet Props => base.def.GetModExtension<Grimworld.ModExtension_PlagueBullet>();

        protected override void Impact(Thing hitThing, bool blockedByShield)
        {
            base.Impact(hitThing);
            if (Props != null && hitThing != null && hitThing is Pawn hitPawn)
            {
                float rand = Rand.Value;
                if (rand <= Props.addHediffChance)
                {
                    Messages.Message("TST_PlagueBullet_SuccessMessage".Translate(
                        this.launcher.Label, hitPawn.Label
                    ), MessageTypeDefOf.NeutralEvent);
                    Hediff plagueOnPawn = hitPawn.health?.hediffSet?.GetFirstHediffOfDef(Props.hediffToAdd);
                    float randomSeverity = Rand.Range(0.15f, 0.30f);
                    if (plagueOnPawn != null)
                    {
                        plagueOnPawn.Severity += randomSeverity;
                    }
                    else
                    {
                        Hediff hediff = HediffMaker.MakeHediff(Props.hediffToAdd, hitPawn);
                        hediff.Severity = randomSeverity;
                        hitPawn.health.AddHediff(hediff);
                    }
                }
                else
                {
                    MoteMaker.ThrowText(hitThing.PositionHeld.ToVector3(), hitThing.MapHeld, "TST_PlagueBullet_FailureMote".Translate(Props.addHediffChance), 12f);
                }
            }
        }
    }
}