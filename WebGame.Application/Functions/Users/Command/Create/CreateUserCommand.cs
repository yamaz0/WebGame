using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Response;
using WebGame.Domain.Entities.Player;
using WebGame.Domain.Entities.User;

namespace WebGame.Application.Functions.Accounts.Command.Create
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IPlayerRepository playerRepository, IUserRepository userRepository)
        {
            _playerRepository = playerRepository;
            _userRepository = userRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserEntity() { UserName = request.Username, Email = request.Email };
            var response = await _userRepository.AddAsync(user, request.Password);
            if (response.Success)//tymczasowo
            {
                var player = new Player() { Name = request.Username, UserId = response.Id };
                await _playerRepository.AddAsync(player);
            }
            return response;
        }
    }
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(20);
        }
    }
    public class CreateUserCommandResponse : BasicResponse
    {
        public string Id { get; set; }

        public CreateUserCommandResponse(IdentityResult identityResult, string id) : base(identityResult.Succeeded)
        {
            Id = id;

            foreach (var error in identityResult.Errors)
            {
                Errors.Add(error.Description);
            }
        }
    }
}
