using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITeamService
    {
        IDataResult<List<Team>> GetList();
        IDataResult<Team> GetById(int teamId);
        IResult Add(Team team);
        IResult Delete(Team team);
        IResult Update(Team team);

        IResult AddTransactionalTest(Team team);
    }
}
