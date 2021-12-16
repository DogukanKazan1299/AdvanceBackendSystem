using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        ICountryDal _countryDal;
        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }
        [ValidationAspect(typeof(CountryValidator))]
        [CacheRemoveAspect("ICountryService.Get")]
        public IResult Add(Country country)
        {

            IResult result = BusinessRules.Run(CheckIfCountryNameExists(country.CountryName));

            if (result != null)
            {
                return result;
            }
            _countryDal.Add(country);
            return new SuccessResult(Messages.AddCountry);
           
            
        }

        public IResult Delete(Country country)
        {
            _countryDal.Delete(country);
            return new SuccessResult(Messages.DeleteCountry);
        }
        [CacheAspect]
        public IDataResult<Country> GetById(int countryId)
        {
            return new SuccessDataResult<Country>(_countryDal.Get(x => x.Id == countryId));
        }
        [CacheAspect]
        public IDataResult<List<Country>> GetList()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetList().ToList());
        }
        [CacheRemoveAspect("ICountryService.Get")]
        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult(Messages.UpdateCountry);
        }
        //istenen->aynı ülkenin adı 2 kere girilemez
        private IResult CheckIfCountryNameExists(string countryName)
        {
            var result = _countryDal.GetList(c => c.CountryName == countryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CountryNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
