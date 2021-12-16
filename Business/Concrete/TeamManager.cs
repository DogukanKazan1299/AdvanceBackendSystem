using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
    public class TeamManager : ITeamService
    {
        ITeamDal _teamDal;
        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }
        [ValidationAspect(typeof(TeamValidator))]
        [SecuredOperation("Team.Add,Admin")]
        [CacheRemoveAspect("ITeamService.Get")]
        public IResult Add(Team team)
        {
            
           
            _teamDal.Add(team);
            return new SuccessResult(Messages.AddTeam);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Team team)
        {
            Add(team);
            if (team.Budget < 0)
            {
                throw new Exception("");
            }
            Add(team);
            return null;
        }

        [CacheRemoveAspect("ITeamService.Get")]
        public IResult Delete(Team team)
        {
            _teamDal.Delete(team);
            return new SuccessResult(Messages.DeleteTeam);
        }
        [CacheAspect]
        public IDataResult<Team> GetById(int id)
        {
            return new SuccessDataResult<Team>(_teamDal.Get(x => x.Id == id));
        }
        [CacheAspect]
        //5.sn den fazla sürerse beni uyar.
        [PerformanceAspect(5)]
        public IDataResult<List<Team>> GetList()
        {
            return new SuccessDataResult<List<Team>>(_teamDal.GetList().ToList());
        }

        [CacheRemoveAspect("ITeamService.Get")]
        public IResult Update(Team team)
        {
            _teamDal.Update(team);
            return new SuccessResult(Messages.UpdateTeam);
        }
    }
}
