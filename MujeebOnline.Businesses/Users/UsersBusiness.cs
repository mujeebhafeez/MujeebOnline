using MujeebOnline.Connector;
using MujeebOnline.Constants;
using MujeebOnline.Entities;
using MujeebOnline.ExceptionsAndLoggings;
using MujeebOnline.Repositories;
using MujeebOnline.Caching;
using MujeebOnline.ViewModels;
using MujeebOnline.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Microsoft.Extensions.Configuration;
using ConfigurationManager = MujeebOnline.Utility.ConfigurationManager;

namespace MujeebOnline.Business
{
    public class UsersBusiness
    {
        private readonly IRepositoryServiceProvider _repositoryServiceProvider;
        private readonly IBusinessProvider _businessProvider;
        private readonly IExternalServiceProvider _externalServiceProvider;


        public UsersBusiness(IBusinessProvider businessProvider, IRepositoryServiceProvider repositoryServiceProvider, IExternalServiceProvider externalServiceProvider)
        {
            _businessProvider = businessProvider;
            _repositoryServiceProvider = repositoryServiceProvider;
            _externalServiceProvider = externalServiceProvider;
        }

        public async Task<APIResponse<List<tbl_Users>>> GetUsersList()
        {
            try
            {
                var usersList = await _repositoryServiceProvider.UsersRepository.GetUsersListFromUsp();
                if (!usersList.IsSucceed)
                    return APIResponse<List<tbl_Users>>.Failed(LanguageTextConstants.Failure, "GetUsersListFromUsp failure");

                return APIResponse<List<tbl_Users>>.Success(usersList.Data, LanguageTextConstants.Success, "GetUsersListFromUsp success");


            }
            catch (Exception ex)
            {

                throw;
            }


        }



}
}
