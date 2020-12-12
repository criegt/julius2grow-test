namespace Julius2GrowTest.Application.UseCases.Users.SignUpUser
{
    public interface IOutputPort
    {
        void Ok();

        void Conflict();
    }
}
