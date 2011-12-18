using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    class FrostboltGameAction : AreaGameAction
    {
        public FrostboltGameAction(Character caster) : base(frostboltDamageRadius)
        {
            this.caster = caster;
        }
        public override void postEffect(GameObject obj)
        {
            obj.Damage(caster, Damage.frost, damageAmount);
        }
        private Character caster = null;
        private const float frostboltDamageRadius = 45;
        private const int damageAmount = 10;
    }
}
