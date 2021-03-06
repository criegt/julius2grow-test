﻿using System.Threading.Tasks;
using Julius2GrowTest.Application.Services;
using Julius2GrowTest.Domain.Users;

namespace Julius2GrowTest.Application.UseCases.Users.SignInUser
{
    public class SignInUserUseCase : ISignInUserUseCase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly Notification _notification;
        private IOutputPort _outputPort;

        public SignInUserUseCase(
            IUserService userService,
            IUserRepository userRepository,
            Notification notification)
        {
            _userService = userService;
            _userRepository = userRepository;
            _notification = notification;
        }

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(string userName, string password)
        {
            var result = await _userService.SignInAsync(userName, password);

            if (result.IsT1)
            {
                _notification.Add("Detail", "User name or password are invalid");
                _outputPort.Invalid();

                return;
            }

            var user = await _userRepository.GetAsync(userName);
            var (token, expiresIn) = _userService.CreateToken(user);

            _outputPort.Ok(new(token, expiresIn));
        }
    }
}
