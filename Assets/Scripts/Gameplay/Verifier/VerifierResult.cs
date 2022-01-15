namespace Pallada.Gameplay.Verifier
{
    public class VerifierResult
    {
        public enum Type
        {
            good,
            failed,
            ignore
        }

        private VerifierResult(Type type)
        {
            this.type = type;
            if (type == Type.failed)
            {
                failed = true;
            }
            else
            {
                failed = false;
            }
        }

        public bool failed { get; }

        public Type type { get; }

        public static VerifierResult GetFailed()
        {
            return new VerifierResult(Type.failed);
        }

        public static VerifierResult GetGood()
        {
            return new VerifierResult(Type.good);
        }

        public static VerifierResult GetIgnore()
        {
            return new VerifierResult(Type.ignore);
        }
    }
}