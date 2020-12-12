namespace Julius2GrowTest.Application.UseCases.Users.SignInUser
{
    public interface IOutputPort
    {
        void Ok(UserSigned userSigned);

        void Invalid();
    }
}
