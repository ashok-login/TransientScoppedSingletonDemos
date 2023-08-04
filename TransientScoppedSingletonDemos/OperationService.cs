namespace TransientScoppedSingletonDemos
{
    public class OperationService : ITransientService, IScoppedService, ISingletonService
    {
        private Guid _id;

        public OperationService()
        {
            _id = Guid.NewGuid();
        }

        public Guid GetOperationId()
        {
            return _id;
        }
    }
}
