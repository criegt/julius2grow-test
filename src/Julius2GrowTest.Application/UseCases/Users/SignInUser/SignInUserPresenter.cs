namespace Julius2GrowTest.Application.UseCases.Users.SignInUser
{
    public class SignInUserPresenter : IOutputPort
    {
        public UserSigned UserSigned { get; private set; }
        public bool InvalidOutput { get; private set; }


        public void Ok(UserSigned userSigned) => UserSigned = userSigned;
        public void Invalid() => InvalidOutput = true;
    }
}
