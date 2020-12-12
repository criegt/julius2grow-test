namespace Julius2GrowTest.Application.UseCases.Users.SignUpUser
{
    public class SignUpUserPresenter : IOutputPort
    {
        public bool OkOutput { get; private set; }
        public bool ConflictOutput { get; private set; }


        public void Ok() => OkOutput = true;
        public void Conflict() => ConflictOutput = true;
    }
}
