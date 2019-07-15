using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            // one way to do this
            //switch (policy.Type)
            //{
            //    case PolicyType.Life:
            //        return new LifePolicyRater(engine, engine.Logger);
            //    case PolicyType.Land:
            //        return new LandPolicyRater(engine, engine.Logger);
            //    case PolicyType.Auto:
            //        return new AutoPolicyRater(engine, engine.Logger);
            //    case PolicyType.Flood:
            //        return new FloodPolicyRater(engine, engine.Logger);
            //    default:
            //        return null;
            //}

            // advanced way to eliminate switch using reflection
            try
            {
                return  (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                    new object[] { engine, engine.Logger });
            }
            catch
            {
                return null;
            }
        }
    }
}
