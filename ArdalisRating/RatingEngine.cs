using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        public FilePolicySerializer PolicySerializer { get; set; } = new FilePolicySerializer();
        public decimal Rating { get; set; }
        public void Rate()
        {
            // Logging - how is delegated
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            // Persistence - how is delegated
            var policyJson = PolicySource.GetPolicyFromSource();

            // Encoding Format - how is delegated
            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            var factory = new RaterFactory();

            var rater = factory.Create(policy, this);
            rater?.Rate(policy);

            Logger.Log("Rating completed.");
        }
    }
}
