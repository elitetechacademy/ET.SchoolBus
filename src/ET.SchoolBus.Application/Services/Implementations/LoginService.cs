using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ET.SchoolBus.Application.DTOs.Common;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Application.Services.Interfaces;
using ET.SchoolBus.Application.Validators;
using ET.SchoolBus.Application.Wrapper;
using ET.SchoolBus.Data.UnitWork;
using ET.SchoolBus.Domain.Entities;
using ET.SchoolBus.Integration.Interfaces;
using ET.SchoolBus.Pack.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ET.SchoolBus.Application.Services.Implementations;

public class LoginService : ILoginService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<LoginService> _logger;
    private readonly ICypherService _cypherService;
    private readonly IConfiguration _configuration;

    public LoginService(IUnitOfWork unitOfWork, ILogger<LoginService> logger, ICypherService cypherService, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _cypherService = cypherService;
        _configuration = configuration;
    }

    public async Task<Result> SignIn(LoginRequestDto loginRequest)
    {
        var validator = new LoginRequestValidator();
        var validationResult = await validator.ValidateAsync(loginRequest, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        try
        {
            var encryptedPassword = _cypherService.Encrypte(loginRequest.Password);
            var loginUser = await _unitOfWork.ApplicationUserRepository.GetApplicationUserByUsernameAndPassword(loginRequest.UserName, encryptedPassword);

            if (loginUser is null)
            {
                return Result.Failure("Kriterlere uyan kullanıcı bulunamadı.");
            }

            var tokenInfo = GenerateToken(loginUser, loginRequest.SeasonId);

            var loginResponse = new LoginResponseDto
            {
                ExpireDate = tokenInfo.ExpireDate,
                UserId = loginUser.UserId,
                Token = tokenInfo.Token
            };
            _logger.LogInformation($"Login işlemi başarılı. Kullanıcı adı : {loginUser.UserName}, Parola : {loginRequest.Password}");
            return Result<LoginResponseDto>.Success(loginResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Kullanıcı bilgileri yüklenemedi");
            return Result.Failure("Kullanıcı bilgileri alınamadı.");
        }

    }


    #region Private Methods

    private TokenInfo GenerateToken(ApplicationUser loginUser, int seasonId)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var expireMinutes = int.Parse(_configuration["Jwt:TokenExpireMinutes"]);
        var expireDate = DateTime.Now.AddMinutes(expireMinutes);

        //Generate Claims
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, loginUser.UserId.ToString()),
            new Claim(ClaimTypes.Role, loginUser.Role.Name),
            new Claim(ClaimTypes.Email, loginUser.Email),
            new Claim(ClaimTypes.Name, loginUser.UserName),
            new Claim("seasonId", seasonId.ToString())
        };

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
          _configuration["Jwt:Audience"],
          claims,
          expires: expireDate,
          signingCredentials: credentials);

        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return new TokenInfo
        {
            ExpireDate = expireDate,
            Token = tokenString
        };
    }

    #endregion

}
