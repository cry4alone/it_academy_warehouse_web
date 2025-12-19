using AutoMapper;
using Microsoft.AspNetCore.Http;
using Storage.BLL.Common;
using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;
using System.Threading;
using Storage.BLL.DTO.Requests.UserRequests;

namespace Storage.BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashingService _passwordHashingService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IPasswordHashingService passwordHashingService, ICurrentUserService currentUserService, IDateTimeProvider dateTimeProvider, IMapper mapper)
    {
        _userRepository = userRepository;
        _passwordHashingService = passwordHashingService;
        _currentUserService = currentUserService;
        _dateTimeProvider = dateTimeProvider;
        _mapper = mapper;
    }

    public async Task<UserResponse> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        
        return _mapper.Map<UserResponse>(user);
    }

    public async Task<UserResponse> CreateUserAsync(CreateUserRequest userRequest, CancellationToken cancellationToken = default)
    {
        var existingUser = await _userRepository.GetByUsernameAsync(userRequest.UserName, cancellationToken);
        if (existingUser != null) throw new Exception("User already exists");
        
        var currentUsername = _currentUserService.GetCurrentUserAsync().Result.Username;
        
        var currentUser = await _userRepository.GetByUsernameAsync(currentUsername, cancellationToken);
        var hashedPassword = _passwordHashingService.HashPassword(userRequest.Password);

        var newUser = new SystemUser()
        {
            PasswordHash = hashedPassword,
            Username = userRequest.UserName ?? string.Empty,
            Surname = userRequest.Surname ?? string.Empty,
            FirstName = userRequest.FirstName ?? string.Empty,
            MiddleName = userRequest.MiddleName,
            CreatedByUser = currentUser,
            CreatedDate = _dateTimeProvider.UtcNow
        };

        await _userRepository.AddUserAsync(newUser, cancellationToken);
        
        return _mapper.Map<UserResponse>(newUser);
    }
}