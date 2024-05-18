using Dapper;
using MujeebOnline.Entities;
using MujeebOnline.ExceptionsAndLoggings;
using System.Collections.Generic;
using System.Data;

namespace MujeebOnline.Repositories
{
    public class UsersRepository : GenericDataAccess
    {
        private readonly IRepositoryServiceProvider _repositoryServiceProvider;

        public UsersRepository(IRepositoryServiceProvider repositoryServiceProvider)
        {
            _repositoryServiceProvider = repositoryServiceProvider;
        }
                
        public async Task<DBResponse<List<tbl_Users>>> GetUsersListFromUsp()
        {
            var parameters = new DynamicParameters();
            //parameters.AddResponseParameters();
            string ProcedureName = "GetUserFromDB";
            var usersList = await GetAll<tbl_Users>(ProcedureName, parameters, CommandType.StoredProcedure);
            //var response = parameters.GetResponse();
            //return new DBResponse<List<tbl_Users>>(response.ResponseCode,response.Description, usersList.ToList());
            return new DBResponse<List<tbl_Users>>(0, "Done", usersList.ToList());

        }
 
    }
}
