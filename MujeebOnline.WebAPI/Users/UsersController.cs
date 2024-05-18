using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MujeebOnline.Business;
using MujeebOnline.Entities;
using MujeebOnline.ExceptionsAndLoggings;
using MujeebOnline.ViewModels;
using MujeebOnline.Utility;
using MujeebOnline.AutoMapper;
using MujeebOnline.Constants;
using Microsoft.AspNetCore.Authorization;

namespace MujeebOnline.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {

        private readonly IBusinessProvider _businessProvider;
        private readonly ISessionManager _sessionManager;
        private readonly IMapper _mapper;

        public UsersController(ISessionManager sessionManager, IBusinessProvider businessProvider, IMapper mapper)
        {
            _businessProvider = businessProvider;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<APIResponse<tbl_Users>> Login(UsersLoginVM request)
        {
            
            var usersList = await _businessProvider.UsersBusiness.GetUsersList();
            if (usersList.IsSucceed && usersList.ResponseData.Count >0)
            {
                var UserDetail = usersList.ResponseData.FirstOrDefault(x => x.UserName == request.LoginName
                && x.UserPassword==request.LoginPassword);
                if (UserDetail == null) 
                return APIResponse<tbl_Users>.Failed(LanguageTextConstants.Failure, "No user found");


                var currentUserDetails = new UserSession()
                {
                    UserID = UserDetail.UserID,
                    UserName = UserDetail.UserName,
                    UserPassword = UserDetail.UserPassword,
                    IsCancelled = UserDetail.IsCancelled,
                    Mydetails1 = $"{UserDetail.UserID} : {UserDetail.UserName} : 1",
                    Mydetails2 = $"{UserDetail.UserID} : {UserDetail.UserName} : 2",
                    UserRequestID = Guid.NewGuid()
                };
                
                _sessionManager.MyUserSession = currentUserDetails;
                return APIResponse<tbl_Users>.Success(UserDetail,LanguageTextConstants.Success, "user found");

            }


            return APIResponse<tbl_Users>.Failed(LanguageTextConstants.Failure, "No user found");


        }


    }
}
