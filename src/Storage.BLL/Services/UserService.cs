using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Models;
using Storage.DAL.Repositories;

namespace Storage.BLL.Services;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;
    private readonly IPasswordHashingService _passwordHashingService;

    public UserService(UserRepository userRepository, IPasswordHashingService passwordHashingService)
    {
        _userRepository = userRepository;
        _passwordHashingService = passwordHashingService;
    }

    public async Task<UserResponse> GetUserByIdAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        
        return new UserResponse(
            user.UserId,
            user.Username,
            user.Surname,
            user.FirstName,
            user.MiddleName);
    }

    public async Task<UserResponse> CreateUserAsync(UserRequest userRequest, string currentUsername)
    {
        var existingUser = await _userRepository.GetByUsernameAsync(userRequest.UserName);
        if (existingUser != null) throw new Exception("User already exists");
        
        var currentUser = await _userRepository.GetByUsernameAsync(currentUsername);
        var hashedPassword = _passwordHashingService.HashPassword(userRequest.Password);

        var newUser = new SystemUser()
        {
            PasswordHash = hashedPassword,
            Username = userRequest.UserName ?? string.Empty,
            Surname = userRequest.Surname ?? string.Empty,
            FirstName = userRequest.FirstName ?? string.Empty,
            MiddleName = userRequest.MiddleName,
            CreatedByUser = currentUser
        };

        await _userRepository.AddUserAsync(newUser);
        
        return new UserResponse(
            newUser.UserId,
            newUser.Username,
            newUser.Surname,
            newUser.FirstName,
            newUser.MiddleName
        );
    }
}