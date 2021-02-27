using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            //return new SuccessDataResult<User>(user, Messages.UserRegistered);
            return new SuccessDataResult<User>(user, "Kayıt oldu");  // bu kısmı refactor edip üstteki hale getir (hocanın github ında var)
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                //return new ErrorDataResult<User>(Messages.UserNotFound);
                return new ErrorDataResult<User>("Kullanıcı bulunamadı");  // bu kısmı refactor edip üstteki hale getir
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                //return new ErrorDataResult<User>(Messages.PasswordError);
                return new ErrorDataResult<User>("Parola hatası");  // bu kısmı refactor edip üstteki hale getir
            }

            //return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
            return new SuccessDataResult<User>(userToCheck, "Başarılı giriş");  // bu kısmı refactor edip üstteki hale getir

        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                //return new ErrorResult(Messages.UserAlreadyExists);
                return new ErrorResult("Kullanıcı mevcut");  // bu kısmı refactor edip üstteki hale getir
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            //return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");   // bu kısmı refactor edip üstteki hale getir
        }
    }
}
