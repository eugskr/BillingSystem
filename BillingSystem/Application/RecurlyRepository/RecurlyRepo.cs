using Infrastructure.RecurlyProvider;


namespace Application.RecurlyRepository
{
    public class RecurlyRepo : IRecurlyRepo
    {
        private readonly IRecurlyAccount _service;
        public RecurlyRepo(IRecurlyAccount service)
        {
            _service = service;
        }
        public void CreateAccount()
        {

            _service.CreateAccount();
        }
    }
}
